using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

class Program
{
    public static async Task Main()
    {
        // Credenciais
        string email = "cafecomcodigoconsultoria@gmail.com";
        string password = "Deusa@0001";

        string loginUrl = "https://sso.hotmart.com/login?service=https%3A%2F%2Fsso.hotmart.com%2Foauth2.0%2FcallbackAuthorize%3Fclient_id%3D8cef361b-94f8-4679-bd92-9d1cb496452d%26scope%3Dopenid%2Bprofile%2Bauthorities%2Bemail%2Buser%2Baddress%26redirect_uri%3Dhttps%253A%252F%252Fapp.hotmart.com%252Fauth%252Flogin%26response_type%3Dcode%26response_mode%3Dquery%26state%3Df58cd89a7c7148b28e6f2a45bd8e4b79%26client_name%3DCasOAuthClient";

        using var playwright = await Playwright.CreateAsync();

        // 1. Configuração "Anti-Bot" (Stealth)
        var launchOptions = new BrowserTypeLaunchOptions
        {
            Headless = false,
            Args = new[] {
                "--disable-blink-features=AutomationControlled",
                "--start-maximized",
                "--no-sandbox"
            },
            IgnoreDefaultArgs = new[] { "--enable-automation" }
        };

        await using var browser = await playwright.Chromium.LaunchAsync(launchOptions);

        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36",
            ViewportSize = null
        });

        // Injeção de Script para apagar vestígios do WebDriver
        await context.AddInitScriptAsync(@"
            Object.defineProperty(navigator, 'webdriver', {
                get: () => undefined
            });
        ");

        var page = await context.NewPageAsync();

        Console.WriteLine("Aguardando requisição do Token...");

        // Setup da interceptação
        var tokenTask = page.WaitForRequestAsync(request =>
            request.Url.Contains("api-vlc.hotmart.com/userprofile/rest/v1/user") &&
            request.Method == "GET");

        try
        {
            await page.GotoAsync(loginUrl);
            await RandomDelay(1000, 2000);

            // --- PASSO 1: E-MAIL ---
            string userSelector = "input[name='username']";
            await page.WaitForSelectorAsync(userSelector);
            await HumanHoverAndClick(page, userSelector);
            await HumanType(page, userSelector, email);

            await RandomDelay(500, 1000);

            // --- PASSO NOVO: FECHAR COOKIES ---
            // Usamos a classe específica do botão que você mandou no HTML
            string cookieButtonSelector = "button.cookie-policy-accept-all";

            // Tenta clicar no cookie se ele aparecer dentro de 5 segundos
            try
            {
                // Verifica se está visível antes de tentar clicar
                if (await page.IsVisibleAsync(cookieButtonSelector))
                {
                    Console.WriteLine("Popup de Cookies detectado. Clicando...");
                    await HumanHoverAndClick(page, cookieButtonSelector);
                    await RandomDelay(500, 1000); // Espera o popup sumir
                }
                else
                {
                    // Às vezes demora um pouco para renderizar, damos uma chance extra
                    await page.WaitForSelectorAsync(cookieButtonSelector, new PageWaitForSelectorOptions { Timeout = 3000 });
                    await HumanHoverAndClick(page, cookieButtonSelector);
                    await RandomDelay(500, 1000);
                }
            }
            catch
            {
                Console.WriteLine("O popup de cookies não apareceu ou já foi aceito.");
            }

            // --- PASSO 2: SENHA ---
            string passSelector = "input[id='password'], input[type='password']";
            await page.WaitForSelectorAsync(passSelector);
            await HumanHoverAndClick(page, passSelector);
            await HumanType(page, passSelector, password);

            await RandomDelay(800, 1500);

            // --- PASSO 3: BOTÃO ENTRAR ---
            string btnSelector = "button[type='submit']";
            await HumanHoverAndClick(page, btnSelector);

        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro na interação: " + ex.Message);
            // return; // Comentei o return para ele tentar esperar o token mesmo se der erro visual
        }

        Console.WriteLine("Login enviado. Aguardando a captura...");

        // Timeout maior para garantir
        var apiRequest = await tokenTask.WaitAsync(TimeSpan.FromSeconds(60));

        if (apiRequest.Headers.TryGetValue("authorization", out var bearerToken))
        {
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("SUCESSO! Token capturado:");
            Console.WriteLine("--------------------------------------------------\n");
            Console.WriteLine(bearerToken);
            Console.WriteLine("\n--------------------------------------------------");
        }
        else
        {
            Console.WriteLine("Header Authorization não encontrado.");
        }

        await Task.Delay(5000);
    }

    // --- MÉTODOS AUXILIARES ---

    private static async Task HumanType(IPage page, string selector, string text)
    {
        var random = new Random();
        foreach (char c in text)
        {
            await page.TypeAsync(selector, c.ToString(), new PageTypeOptions { Delay = 0 });
            await Task.Delay(random.Next(50, 150));
        }
    }

    private static async Task HumanHoverAndClick(IPage page, string selector)
    {
        await page.HoverAsync(selector);
        await RandomDelay(200, 500);
        await page.ClickAsync(selector);
    }

    private static async Task RandomDelay(int min, int max)
    {
        await Task.Delay(new Random().Next(min, max));
    }
}