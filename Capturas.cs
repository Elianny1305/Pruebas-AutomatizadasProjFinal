using OpenQA.Selenium;


public static class Capturas
{
    public static void TakeScreenshot(IWebDriver driver, string capture_name)
    {
        
        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        
        string Basefolder = "C:/Users/Elianny/OneDrive - Instituto Tecnológico de Las Américas (ITLA)/" +
            "Escritorio/prueba/Prueba_Automatizada";
        
        //Ruta de guardado

        string path_screenshot = Path.Combine(Basefolder, "Capturas");
  
        Directory.CreateDirectory(path_screenshot);
        
        string screenshotPath = Path.Combine(path_screenshot, $"{capture_name}.png");
        
        screenshot.SaveAsFile(screenshotPath);

    }
}
