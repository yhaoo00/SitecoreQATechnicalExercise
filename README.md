# SitecoreQATechnicalExercise
Technical Exercise for Sitecore QA Engineer role

## Dependencies
* .NET Framework 4.7.2
* Selenium.WebDriver 4.11.0
* Selenium.WebDriver.ChromeDriver 115.0.5790.17000

## Assumptions
* This project created with Visual Studio 2022
* Uses chrome webdriver provided by `OpenQA.Selenium.Chrome` (no need to download externally)


## Instruction
1. Just press F5 in Visual Studio to run.

## Remarks
1. User might encounter CAPTCHA page while navigate to Amazon, so there will be workarounds.
    1. User can change the URL to https://www.amazon.sg/
    2. User can use the `IsCaptchaPage` function provided in the code to manually enter CAPTCHA:
        * When at CAPTCHA page, user can go to Console App and enter in CAPTCHA
        * Press ENTER and the CAPTCHA will key in and continue the automation process
        * __FYI__: This method might eliminates the purpose of automation which stated in the document, but only __THIS__ step, there rest are still automated.
2. Can put a breakpoint (F9) at `driver.Quit()` so that you can observe the result in Console App.