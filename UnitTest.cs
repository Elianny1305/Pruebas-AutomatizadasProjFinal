using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Prueba_Automatizada
{
    public class Tests
    {
        private IWebDriver driver;


        [SetUp]
        public void Setup()
        {

            driver = new ChromeDriver();

            // Navegando hacia la aplicacion

            driver.Navigate().GoToUrl("http://localhost:5020");
           

        }

        [Test]
        public void LoginTest()
        {


            IWebElement usuario = driver.FindElement(By.Id("user"));

            IWebElement password = driver.FindElement(By.Id("password"));

            IWebElement ingresar = driver.FindElement(By.Id("confirm_button"));


            usuario.SendKeys("jose");

            password.SendKeys("1234");

            Capturas.TakeScreenshot(driver, "Datos_Ingresados");

            ingresar.Click();

            Capturas.TakeScreenshot(driver, "Inicio_sesion");

            driver.Quit();

        }

        [Test]
        public void LoginTestFall()
        {


            IWebElement usuario = driver.FindElement(By.Id("user"));

            IWebElement password = driver.FindElement(By.Id("password"));

            IWebElement ingresar = driver.FindElement(By.Id("confirm_button"));


            usuario.SendKeys("juan");

            password.SendKeys("5454");

            Capturas.TakeScreenshot(driver, "Datos_Ingresados");

            ingresar.Click();

            Capturas.TakeScreenshot(driver, "fallido");

            driver.Quit();

        }


        [Test]
        public void LoginVacioTest()
        {


            IWebElement usuario = driver.FindElement(By.Id("user"));

            IWebElement password = driver.FindElement(By.Id("password"));

            IWebElement ingresar = driver.FindElement(By.Id("confirm_button"));


            Capturas.TakeScreenshot(driver, "login");

            ingresar.Click();

            Capturas.TakeScreenshot(driver, "Inicio_sesion");

            driver.Quit();

        }



        [Test]
        public void NavTet()

        {


            IWebElement usuario = driver.FindElement(By.Id("user"));

            IWebElement password = driver.FindElement(By.Id("password"));

            IWebElement ingresar = driver.FindElement(By.Id("confirm_button"));


            usuario.SendKeys("jose");

            password.SendKeys("1234");

            ingresar.Click();


            IWebElement inicio = driver.FindElement(By.Id("user"));

            IWebElement passwords = driver.FindElement(By.Id("password"));

            IWebElement confirmar = driver.FindElement(By.Id("confirm_button"));






            driver.Quit();


        }

        [Test]
        public void AccidentRegistrationFormValidationTest()
        {
            IWebElement usuario = driver.FindElement(By.Id("user"));

            IWebElement password = driver.FindElement(By.Id("password"));

            IWebElement ingresar = driver.FindElement(By.Id("confirm_button"));


            usuario.SendKeys("jose");

            password.SendKeys("1234");

            ingresar.Click();

            IWebElement descripcion = driver.FindElement(By.Id("descripcion"));

            IWebElement costo = driver.FindElement(By.Id("costo"));

            IWebElement muertos = driver.FindElement(By.Id("muertos"));

        }

        [Test]
        public void NavigationToAccidentDetailsPageTest()
        {
            // Prueba de navegación a la página de detalles de un accidente
            IWebElement detailsButton = driver.FindElement(By.TagName("button"));
            detailsButton.Click();
            Assert.IsTrue(driver.Url.Contains("/datos"));
        }

        [Test]
        public void AccidentDetailsVisualizationTest()
        {
            // Prueba de visualización de detalles de un accidente
            IWebElement fecha = driver.FindElement(By.XPath("//ul/li[1]/p"));
            Assert.IsNotNull(fecha.Text);
            IWebElement descripcion = driver.FindElement(By.XPath("//ul/li[2]/p"));
            Assert.IsNotNull(descripcion.Text);
            // Continuar verificando los otros elementos de la página de detalles
        }

        [Test]
        public void RegisteredAccidentsCountTest()
        {
            // Prueba de conteo de accidentes registrados
            var registros = driver.FindElements(By.XPath("//tbody/tr")).Count;
            Assert.IsTrue(registros > 0);
        }

        [Test]
        public void VehiclesInvolvedCalculationTest()
        {
            // Prueba de cálculo de vehículos involucrados
            var vehiculos = driver.FindElements(By.XPath("//tbody/tr/td[3]"));
            int totalVehiculos = 0;
            foreach (var vehiculo in vehiculos)
            {
                totalVehiculos += int.Parse(vehiculo.Text);
            }
            Assert.IsTrue(totalVehiculos >= 0);
        }

        [Test]
        public void FatalitiesCalculationTest()
        {
            // Prueba de cálculo de muertos
            var muertos = driver.FindElements(By.XPath("//tbody/tr/td[4]"));
            int totalMuertos = 0;
            foreach (var muerto in muertos)
            {
                totalMuertos += int.Parse(muerto.Text);
            }
            Assert.IsTrue(totalMuertos >= 0);
        }

        [Test]
        public void InjuriesCalculationTest()
        {
            // Prueba de cálculo de heridos
            var heridos = driver.FindElements(By.XPath("//tbody/tr/td[5]"));
            int totalHeridos = 0;
            foreach (var herido in heridos)
            {
                totalHeridos += int.Parse(herido.Text);
            }
            Assert.IsTrue(totalHeridos >= 0);
        }

        [Test]
        public void RegisteredAccidentsListVisualizationTest()
        {
            // Prueba de visualización de la lista de accidentes registrados
            var registros = driver.FindElements(By.XPath("//tbody/tr"));
            Assert.IsTrue(registros.Count > 0);
        }

        [Test]
        public void NavigationToAccidentRegistrationPageTest()
        {
            // Prueba de navegación a la página de registro de accidentes
            IWebElement registerButton = driver.FindElement(By.XPath("//button[@onclick='()=>navegar(registro.Id)']"));
            registerButton.Click();
            Assert.IsTrue(driver.Url.Contains("/agregarRegistro"));
        }

        [Test]
        public void NavigationToHomePageFromAccidentRegistrationPageTest()
        {
            // Prueba de navegación a la página de inicio desde la página de registro de accidentes
            IWebElement homeButton = driver.FindElement(By.XPath("//button[@onclick='()=>NavegarInicio()']"));
            homeButton.Click();
            Assert.IsTrue(driver.Url.Contains("/inicio"));
        }

        [Test]
        public void NavigationToAccidentDetailsPageFromAccidentRegistrationPageTest()
        {
            // Prueba de navegación a la página de detalles de un accidente desde la página de registro de accidentes
            IWebElement detailsButton = driver.FindElement(By.XPath("//button[@onclick='()=>navegar(registro.Id)']"));
            detailsButton.Click();
            Assert.IsTrue(driver.Url.Contains("/datos"));
        }

    }

}