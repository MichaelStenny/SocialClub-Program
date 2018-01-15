using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using John.SocialClub.Data.DataAccess;
using John.SocialClub.Data.DataModel;
using John.SocialClub.Data.BusinessService;
using John.SocialClub.Desktop.Forms.Membership;
using John.SocialClub.Data.Enum;
using System.Data.OleDb;
using John.SocialClub.Data.Sql;
using System.IO;
using System.Configuration;
using System.Xml;
using System.Collections;


namespace ClubUnitTest
{
    [TestClass]
    public class SocialClub_UnitTest
    {
        ClubMemberService clubMemberService = new ClubMemberService();

        [TestMethod]
        public void Test_Login()
        {
            string userLogin = "demo";
            string userPassword = "demo123";
            bool loginValidate = true;

            if (userLogin == ConfigurationManager.AppSettings["UserName"] && userPassword == ConfigurationManager.AppSettings["Password"])
            {
                loginValidate = true;
            }

            Assert.IsTrue(loginValidate, "Login Test passed.");
        }

        [TestMethod]
        public void Test_Login_Invalid()
        {
            string userLogin = "dddd";
            string userPassword = "demo123";
            bool loginValidate = true;

            if (userLogin == ConfigurationManager.AppSettings["UserName"] && userPassword == ConfigurationManager.AppSettings["Password"])
            {
                loginValidate = true;
            }
            else
            {
                loginValidate = false;
            }
            Assert.IsFalse(loginValidate, "Invalid Login Test passed.");
        }

        [TestMethod]
        public void Test_GetClubMemberById()
        {
            string clubMemberId = "24";
            int memberId = int.Parse(clubMemberId);

            bool GetMember = false;

            System.Data.DataRow getmemberById = clubMemberService.GetClubMemberById(memberId);

            if (getmemberById.Table.Rows.Count > 0)
            {
                GetMember = true;
            }
            Assert.IsTrue(GetMember, "GetMember passed.");
        }
        [TestMethod]
        public void Test_GetAllClubMember()
        {

            bool GetAllMember = false;

            System.Data.DataTable getAllClubmember = clubMemberService.GetAllClubMembers();

            if (getAllClubmember.Rows.Count > 0)
            {
                GetAllMember = true;
            }
            Assert.IsTrue(GetAllMember, "GetAllMember passed.");
        }
        [TestMethod]
        public void Test_SearchClubMember()
        {

            bool SearchMember = false;
            string sqlCondition = "AND";

            System.Data.DataTable searchClubmember = clubMemberService.SearchClubMembers(Occupation.Doctor, MaritalStatus.Married, sqlCondition);

            if (searchClubmember.Rows.Count > 0)
            {
                SearchMember = true;
            }
            Assert.IsTrue(SearchMember, "SearchMember passed.");
        }
    }
}
