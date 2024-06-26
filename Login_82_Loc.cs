using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.ObjectModel;

namespace SpotifyTest_82_Loc
{
    [TestClass]
    public class Login_82_Loc
    {
        public IWebDriver driver_82_Loc;
        public string baseUrl_82_Loc;
        public TestContext TestContext { get; set; }


        [TestInitialize]
        public void SetUp()
        {
            this.driver_82_Loc = new ChromeDriver();
            this.baseUrl_82_Loc = "https://accounts.spotify.com/vi/status";
        }

        [TestMethod]
        public void TestLoginSuccess_82_Loc()
        {
            // điều hướng đến trang đăng nhập của spotify
            string loginUrl_82_Loc = "https://accounts.spotify.com/vi/login";
            this.driver_82_Loc.Navigate().GoToUrl(loginUrl_82_Loc);

            // Tìm kiếm các input nhập username và password
            IWebElement usernameInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-username"));
            IWebElement passwordInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-password"));

            // Truyền các giá trị username và password
            usernameInput_82_Loc.SendKeys("hongloc111990@gmail.com");
            passwordInput_82_Loc.SendKeys("hongloc82#@!");

            // Click vào button đăng nhập
            IWebElement buttonLogin_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-button"));
            buttonLogin_82_Loc.Click();
            Thread.Sleep(4000);

            // lấy đường dẫn hiện tại, nếu đăng nhập thành công sẽ chuyển về trang có đường dẫn https://accounts.spotify.com/vi/status
            string currentUrl_82_Loc = this.driver_82_Loc.Url;

            // So sánh với đường dẫn hiện tại với đường dẫn https://accounts.spotify.com/vi/status
            Assert.AreEqual(this.baseUrl_82_Loc, currentUrl_82_Loc);

            // Đóng Chrome
            driver_82_Loc.Close();
        }

        [TestMethod]
        // để đọc file *.csv
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data\LoginFailTestcases_82_Loc.csv", "LoginFailTestcases_82_Loc#csv", DataAccessMethod.Sequential)]
        public void TestLoginFail_82_Loc()
        {
            // điều hướng đến trang đăng nhập
            string loginUrl_82_Loc = "https://accounts.spotify.com/vi/login";
            this.driver_82_Loc.Navigate().GoToUrl(loginUrl_82_Loc);

            // tìm các input username và password
            IWebElement usernameInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-username"));
            IWebElement passwordInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-password"));

            // Đọc các giá trí username và password từ file CSV
            string username_82_Loc = TestContext.DataRow[0].ToString();
            string password_82_Loc = TestContext.DataRow[1].ToString();

            // Truyền các giá trị cho username và password
            usernameInput_82_Loc.SendKeys(username_82_Loc);
            passwordInput_82_Loc.SendKeys(password_82_Loc);

            // Tìm và click vào nút đăng nhập
            IWebElement buttonLogin_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-button"));
            buttonLogin_82_Loc.Click();
            Thread.Sleep(2000);

            // Tìm element có cảnh báo 
            IWebElement errorMessage_82_Loc = this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/div[1]/div/span"));
            // So sánh thông điệp cảnh báo tương ứng
            Assert.AreEqual("Tên người dùng hoặc mật khẩu không chính xác.", errorMessage_82_Loc.Text.Trim(), "Unexpected error message.");
            Thread.Sleep(3000);
            // đóng trình duyệt
            this.driver_82_Loc.Close();
        }
    }
}
