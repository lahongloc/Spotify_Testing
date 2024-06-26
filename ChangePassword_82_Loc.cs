using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Collections.ObjectModel;

namespace SpotifyTest_82_Loc
{
    [TestClass]
    public class ChangePassword_82_Loc
    {
        public IWebDriver driver_82_Loc;
        public string baseUrl_82_Loc;
        public TestContext TestContext { get; set; }
        [TestInitialize]
        public void SetUp()
        {
            this.driver_82_Loc = new ChromeDriver();
            // Gán giá trị cho baseUrl_82_Loc là url của trang thay đổi mật khẩu của Spotify
            this.baseUrl_82_Loc = "https://www.spotify.com/vn-vi/account/change-password/";
        }

        [TestMethod]
        public void ChangePasswordSuccess_82_Loc()
        {
            // điều hướng đến trang đăng nhập của Spotify
            string loginUrl_82_Loc = "https://accounts.spotify.com/vi/login";
            this.driver_82_Loc.Navigate().GoToUrl(loginUrl_82_Loc);

            // tìm kiếm các input chứa username và password
            IWebElement usernameInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-username"));
            IWebElement passwordInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-password"));

            // gửi các giá trị của username và password
            usernameInput_82_Loc.SendKeys("loclun001233@gmail.com");
            passwordInput_82_Loc.SendKeys("Omc6789#@!");

            // Tìm và click vào button đăng nhập
            IWebElement buttonLogin_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-button"));
            buttonLogin_82_Loc.Click();
            Thread.Sleep(4000);

            // điều hướng đến trang chủ của Spotify
            IWebElement buttonGoToHome_82_Loc = this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/button[2]"));
            buttonGoToHome_82_Loc.Click();

            Thread.Sleep(2000);

            // điều hướng đến trang đổi mật khẩu
            this.driver_82_Loc.Navigate().GoToUrl(this.baseUrl_82_Loc);

            // truyền các giá trị MẬT KHẨU HIỆN TẠI, MẬT KHẨU MỚI, MẬT KHẨU MỚI XÁC NHẬN đến các input element tương ứng
            this.driver_82_Loc.FindElement(By.Id("old_password")).SendKeys("hongloc82#@!#@!");
            this.driver_82_Loc.FindElement(By.Id("new_password")).SendKeys("hongloc82#@!#@!");
            this.driver_82_Loc.FindElement(By.Id("new_password_confirmation")).SendKeys("hongloc82#@!");

            // Tìm và click vào button đổi mật khẩu
            this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/article/section/form/div[4]/button")).Click();
            Thread.Sleep(2000);

            // Lấy text từ element hiển thị cảnh báo hoặc thông báo
            string successMessage_82_Loc = this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/section/div/span/span")).Text.Trim();

            // so sánh các thông điệp cảnh báo, thông báo
            Assert.AreEqual("Mật khẩu đã được cập nhật", successMessage_82_Loc, "Unexpected error message.");
            Thread.Sleep(1500);

            // đóng trình duyệt
            this.driver_82_Loc.Close();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data\ChangePassFailE1_82_Loc.csv", "ChangePassFailE1_82_Loc#csv", DataAccessMethod.Sequential)]
        public void ChangePasswordFailE1_82_Loc()
        {
            // điều hướng đến trang đăng nhập của Spotify
            string loginUrl_82_Loc = "https://accounts.spotify.com/vi/login";
            this.driver_82_Loc.Navigate().GoToUrl(loginUrl_82_Loc);

            // tìm kiếm các input chứa username và password
            IWebElement usernameInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-username"));
            IWebElement passwordInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-password"));

            // gửi các giá trị của username và password
            usernameInput_82_Loc.SendKeys("hongloc111990@gmail.com");
            passwordInput_82_Loc.SendKeys("hongloc82#@!");

            // Tìm và click vào button đăng nhập
            IWebElement buttonLogin_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-button"));
            buttonLogin_82_Loc.Click();
            Thread.Sleep(4000);

            // điều hướng đến trang chủ của Spotify
            IWebElement buttonGoToHome_82_Loc = this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/button[2]"));
            buttonGoToHome_82_Loc.Click();

            Thread.Sleep(2000);

            // điều hướng đến trang đổi mật khẩu
            this.driver_82_Loc.Navigate().GoToUrl(this.baseUrl_82_Loc);

            // đọc các giá trị MẬT KHẨU HIỆN TẠI, MẬT KHẨU MỚI, MẬT KHẨU MỚI XÁC NHẬN từ file csv
            string currentPass_82_Loc = TestContext.DataRow[0].ToString();
            string newPass_82_Loc = TestContext.DataRow[1].ToString();
            string confirmPass_82_Loc = TestContext.DataRow[2].ToString();

            // truyền các giá trị MẬT KHẨU HIỆN TẠI, MẬT KHẨU MỚI, MẬT KHẨU XÁC NHẬN đến các input element tương ứng
            this.driver_82_Loc.FindElement(By.Id("old_password")).SendKeys(currentPass_82_Loc);
            Thread.Sleep(1200);
            this.driver_82_Loc.FindElement(By.Id("new_password")).SendKeys(newPass_82_Loc);
            Thread.Sleep(1200);
            this.driver_82_Loc.FindElement(By.Id("new_password_confirmation")).SendKeys(confirmPass_82_Loc);
            Thread.Sleep(1200);

            // tìm và click vào button đổi mật khẩu
            this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/article/section/form/div[4]/button")).Click();
            Thread.Sleep(1200);

            // lấy text từ các cảnh báo
            string errorMessage_82_Loc = this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/section/div/span/span")).Text.Trim();

            // so sánh các cảnh báo
            Assert.AreEqual("Không đáp ứng yêu cầu về mật khẩu.", errorMessage_82_Loc, "Unexpected error message.");
            Thread.Sleep(2000);

            // đóng trình duyệt
            this.driver_82_Loc.Close();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data\ChangePassFailE2_82_Loc.csv", "ChangePassFailE2_82_Loc#csv", DataAccessMethod.Sequential)]
        public void ChangePasswordFailE2_82_Loc()
        {
            // điều hướng đến trang đăng nhập của Spotify
            string loginUrl_82_Loc = "https://accounts.spotify.com/vi/login";
            this.driver_82_Loc.Navigate().GoToUrl(loginUrl_82_Loc);

            // tìm kiếm các input chứa username và password
            IWebElement usernameInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-username"));
            IWebElement passwordInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-password"));

            // gửi các giá trị của username và password
            usernameInput_82_Loc.SendKeys("hongloc111990@gmail.com");
            passwordInput_82_Loc.SendKeys("hongloc82#@!");

            // Tìm và click vào button đăng nhập
            IWebElement buttonLogin_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-button"));
            buttonLogin_82_Loc.Click();
            Thread.Sleep(4000);

            // điều hướng đến trang chủ của Spotify
            IWebElement buttonGoToHome_82_Loc = 
                this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/button[2]"));
            buttonGoToHome_82_Loc.Click();
            Thread.Sleep(2000);

            // điều hướng đến trang đổi mật khẩu
            this.driver_82_Loc.Navigate().GoToUrl(this.baseUrl_82_Loc);

            // đọc các giá trị MẬT KHẨU HIỆN TẠI, MẬT KHẨU MỚI, MẬT KHẨU MỚI XÁC NHẬN từ file csv
            string currentPass_82_Loc = TestContext.DataRow[0].ToString();
            string newPass_82_Loc = TestContext.DataRow[1].ToString();
            string confirmPass_82_Loc = TestContext.DataRow[2].ToString();

            // truyền các giá trị MẬT KHẨU HIỆN TẠI, MẬT KHẨU MỚI, MẬT KHẨU XÁC NHẬN đến các input element tương ứng
            this.driver_82_Loc.FindElement(By.Id("old_password")).SendKeys(currentPass_82_Loc);
            Thread.Sleep(1200);
            this.driver_82_Loc.FindElement(By.Id("new_password")).SendKeys(newPass_82_Loc);
            Thread.Sleep(1200);
            this.driver_82_Loc.FindElement(By.Id("new_password_confirmation")).SendKeys(confirmPass_82_Loc);
            Thread.Sleep(1200);

            // tìm và click vào button đổi mật khẩu
            this.driver_82_Loc.
                FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/article/section/form/div[4]/button")).Click();
            Thread.Sleep(1200);

            // so sánh các cảnh báo
            string errorMessage_82_Loc = 
                this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/article/section/form/div[3]/div[3]/span")).Text.Trim();
            Assert.AreEqual("Vui lòng xác minh mật khẩu của bạn.", errorMessage_82_Loc, "Unexpected error message.");
            Thread.Sleep(2000);
            // đóng trình duyệt
            this.driver_82_Loc.Close();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data\ChangePassFailE4_82_Loc.csv", "ChangePassFailE4_82_Loc#csv", DataAccessMethod.Sequential)]
        public void ChangePasswordFailE4_82_Loc()
        {
            // điều hướng đến trang đăng nhập của Spotify
            string loginUrl_82_Loc = "https://accounts.spotify.com/vi/login";
            this.driver_82_Loc.Navigate().GoToUrl(loginUrl_82_Loc);

            // tìm kiếm các input chứa username và password
            IWebElement usernameInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-username"));
            IWebElement passwordInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-password"));

            // gửi các giá trị của username và password
            usernameInput_82_Loc.SendKeys("hongloc111990@gmail.com");
            passwordInput_82_Loc.SendKeys("hongloc82#@!");

            // Tìm và click vào button đăng nhập
            IWebElement buttonLogin_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-button"));
            buttonLogin_82_Loc.Click();
            Thread.Sleep(4000);

            // điều hướng đến trang chủ của Spotify
            IWebElement buttonGoToHome_82_Loc = this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/button[2]"));
            buttonGoToHome_82_Loc.Click();
            Thread.Sleep(2000);

            // điều hướng đến trang đổi mật khẩu
            this.driver_82_Loc.Navigate().GoToUrl(this.baseUrl_82_Loc);

            // đọc các giá trị MẬT KHẨU HIỆN TẠI, MẬT KHẨU MỚI, MẬT KHẨU MỚI XÁC NHẬN từ file csv        
            string currentPass_82_Loc = TestContext.DataRow[0].ToString();
            string newPass_82_Loc = TestContext.DataRow[1].ToString();
            string confirmPass_82_Loc = TestContext.DataRow[2].ToString();

             // truyền các giá trị MẬT KHẨU HIỆN TẠI, MẬT KHẨU MỚI, MẬT KHẨU XÁC NHẬN đến các input element tương ứng
            this.driver_82_Loc.FindElement(By.Id("old_password")).SendKeys(currentPass_82_Loc);
            Thread.Sleep(1200);
            this.driver_82_Loc.FindElement(By.Id("new_password")).SendKeys(newPass_82_Loc);
            Thread.Sleep(1200);
            this.driver_82_Loc.FindElement(By.Id("new_password_confirmation")).SendKeys(confirmPass_82_Loc);
            Thread.Sleep(1200);
            // tìm và click vào button đổi mật khẩu
            this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/article/section/form/div[4]/button")).Click();
            Thread.Sleep(1200);

            // so sánh các cảnh báo
            string errorMessage_82_Loc = 
                this.driver_82_Loc.
                FindElement(By.
                CssSelector("#__next > div.encore-layout-themes.encore-dark-theme > div " +
                "> div.sc-85f631f4-0.ieLURn > div.sc-decd1ee7-0.hYa-doI > article " +
                "> section > form > div:nth-child(1) > div.Help-sc-1xezfve-0.bOtuvO > span")).Text.Trim();

            Assert.AreEqual("Rất tiếc, mật khẩu không chính xác", errorMessage_82_Loc, "Unexpected error message.");
            Thread.Sleep(2000);
            // đóng trình duyệt
            this.driver_82_Loc.Close();
        }

        [TestMethod]
        public void ChangePasswordFailE3_82_Loc()
        {
            // điều hướng đến trang đăng nhập của Spotify
            string loginUrl_82_Loc = "https://accounts.spotify.com/vi/login";
            this.driver_82_Loc.Navigate().GoToUrl(loginUrl_82_Loc);

            // tìm kiếm các input chứa username và password
            IWebElement usernameInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-username"));
            IWebElement passwordInput_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-password"));

            // gửi các giá trị của username và password
            usernameInput_82_Loc.SendKeys("hongloc111990@gmail.com");
            passwordInput_82_Loc.SendKeys("hongloc82#@!");

            // Tìm và click vào button đăng nhập
            IWebElement buttonLogin_82_Loc = this.driver_82_Loc.FindElement(By.Id("login-button"));
            buttonLogin_82_Loc.Click();
            Thread.Sleep(4000);

            // điều hướng đến trang chủ của Spotify
            IWebElement buttonGoToHome_82_Loc = this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"root\"]/div/div[2]/div/div/button[2]"));
            buttonGoToHome_82_Loc.Click();
            Thread.Sleep(2000);

            // điều hướng đến trang đổi mật khẩu
            this.driver_82_Loc.Navigate().GoToUrl(this.baseUrl_82_Loc);

            // truyền các giá trị MẬT KHẨU HIỆN TẠI, MẬT KHẨU MỚI, MẬT KHẨU XÁC NHẬN đến các input element tương ứng
            this.driver_82_Loc.FindElement(By.Id("old_password")).SendKeys("hongloc82#@!");
            Thread.Sleep(1200);
            this.driver_82_Loc.FindElement(By.Id("new_password")).SendKeys("hongloc82#@!");
            Thread.Sleep(1200);
            this.driver_82_Loc.FindElement(By.Id("new_password_confirmation")).SendKeys("hongloc82#@!");
            Thread.Sleep(1200);

            // click vào button đổi mật khẩu
            this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/article/section/form/div[4]/button")).Click();
            Thread.Sleep(1200);

            // so sánh các cảnh báo
            string errorMessage_82_Loc = 
                this.driver_82_Loc.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[2]/article/section/form/div[2]/div[4]/span")).Text.Trim();
            Assert.AreEqual("Chọn mật khẩu mà bạn chưa từng dùng trước đây.", errorMessage_82_Loc, "Unexpected error message.");
            Thread.Sleep(2000);
            // đóng trình duyệt
            this.driver_82_Loc.Close();
        }
    }
}
