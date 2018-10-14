using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
namespace Mycontacs
{
    public partial class StudentInfoBLL
    {
        //XML文件路径
        private static string _basePath =
            AppDomain.CurrentDomain.SetupInformation.ApplicationBase
            + @"//myContacts.xml";
        //XML BackUp文件路径
        private static string _BackUp_basePath =
            AppDomain.CurrentDomain.SetupInformation.ApplicationBase
            + @"//myContacts_BackUp.xml";

        //返回文件路径
        public static string Return_BasePath()
        {
            return _basePath;
        }

        //返回BackUp文件路径
        public static string Return_BackUpPath()
        {
            return _BackUp_basePath;
        }

        //创建_Path_路径的xml文档
        public static void CreateXml(string _Path_)
        {
            //创建XML文档  
            XDocument ContactDoc = new XDocument();
            //创建声明对象  
            XDeclaration xDeclaration = new XDeclaration("1.0", "utf-8", "yes");
            ContactDoc.Declaration = xDeclaration;    //指定XML声明对象  
                                                      //创建节点  
            XElement xElement = new XElement("myContacts");

            //保存文件  
            ContactDoc.Add(xElement);
            ContactDoc.Save(_Path_);
        }

        //获取_Path路径xml文件所有节点信息
        public static List<StudentInfo> GetAllContactsInfo(string _Path)
        {

            List<StudentInfo> contactsList = new List<StudentInfo>();
            XElement xml = XElement.Load(_Path);
            var contactVar = xml.Descendants("contact");

            contactsList = (from contact
                            in contactVar
                            select new StudentInfo
                            {
                                ContactId = Int32.Parse(contact.Attribute("ContactId").Value),
                                Name = contact.Element("Name").Value,
                                Gender = contact.Element("Gender").Value,
                                Age = Int32.Parse(contact.Element("Age").Value),
                                Birthdate = DateTime.Parse(contact.Element("Birthdate").Value),
                                Phone = contact.Element("Phone").Value,
                                Profession = contact.Element("Profession").Value,
                                Email = contact.Element("Email").Value,
                                Adress = contact.Element("Adress").Value
                            }).ToList();
            return contactsList;
        }
        /*
         * 获取一个ID为Contact_ID的节点信息
         */
        public static StudentInfo GetOneContactInfo(int Contact_ID)
        {
            StudentInfo class_Contacts = new StudentInfo();

            XElement xml = XElement.Load(_basePath);
            class_Contacts = (
                from contact
                in xml.Descendants("contact")
                where contact.Attribute("ContactId").Value == Contact_ID.ToString()
                select new StudentInfo
                {
                    ContactId = Int32.Parse(contact.Attribute("ContactId").Value),
                    Name = contact.Element("Name").Value,
                    Gender = contact.Element("Gender").Value,
                    Age = Int32.Parse(contact.Element("Age").Value),
                    Birthdate = DateTime.Parse(contact.Element("Birthdate").Value),
                    Phone = contact.Element("Phone").Value,
                    Profession = contact.Element("Profession").Value,
                    Email = contact.Element("Email").Value,
                    Adress = contact.Element("Adress").Value
                }
                ).Single();

            return class_Contacts;
        }
        /*
         * 获取列表信息（查找）
         */
        public static List<StudentInfo> GetContactsList(StudentInfo param)
        {
            List<StudentInfo> ContactsList = new List<StudentInfo>();
            XElement xml = XElement.Load(_basePath);
            var contactVar = xml.Descendants("contact");

            if (param.ContactId != 0)
            {
                contactVar = xml.Descendants("contact").Where(a => a.Attribute("ContactId").Value == param.ContactId.ToString());
            }
            else if (!String.IsNullOrEmpty(param.Name))
            {
                contactVar = xml.Descendants("contact").Where(a => a.Element("Name").Value == param.Name);
            }

            ContactsList = (from contact
                            in contactVar
                            select new StudentInfo
                            {
                                ContactId = Int32.Parse(contact.Attribute("ContactId").Value),
                                Name = contact.Element("Name").Value,
                                Gender = contact.Element("Gender").Value,
                                Age = Int32.Parse(contact.Element("Age").Value),
                                Birthdate = DateTime.Parse(contact.Element("Birthdate").Value),
                                Phone = contact.Element("Phone").Value,
                                Profession = contact.Element("Profession").Value,
                                Email = contact.Element("Email").Value,
                                Adress = contact.Element("Adress").Value
                            }
                           ).ToList();

            return ContactsList;
        }
        /*
         * 添加信息
         */
        public static bool AddContactInfo(StudentInfo param)
        {
            XElement xml = XElement.Load(_basePath);

            XElement ContactXml = new XElement("contact");

            ContactXml.Add(new XAttribute("ContactId", param.ContactId));
            ContactXml.Add(new XElement("Name", param.Name));
            ContactXml.Add(new XElement("Gender", param.Gender));
            ContactXml.Add(new XElement("Age", param.Age));
            ContactXml.Add(new XElement("Birthdate", param.Birthdate.ToString("yyyy,MM,dd")));
            ContactXml.Add(new XElement("Phone", param.Phone));
            ContactXml.Add(new XElement("Profession", param.Profession));
            ContactXml.Add(new XElement("Email", param.Email));
            ContactXml.Add(new XElement("Adress", param.Adress));

            xml.Add(ContactXml);
            xml.Save(_basePath);

            return true;
        }
        /*
         * 修改信息
         */
        public static bool UpdateContactInfo(StudentInfo param)
        {
            bool Result = false;
            if (param.ContactId > 0)
            {
                XElement xml = XElement.Load(_basePath);

                XElement ContactXml =
                    (
                        from db
                        in xml.Descendants("contact")
                        where db.Attribute("ContactId").Value == param.ContactId.ToString()
                        select db
                    ).Single();

                ContactXml.SetElementValue("Name", param.Name);
                ContactXml.SetElementValue("Gender", param.Gender);
                ContactXml.SetElementValue("Age", param.Age.ToString());
                ContactXml.SetElementValue("Birthdate", param.Birthdate.ToString("yyyy,MM,dd"));
                ContactXml.SetElementValue("Phone", param.Phone);
                ContactXml.SetElementValue("Profession", param.Profession);
                ContactXml.SetElementValue("Email", param.Email);
                ContactXml.SetElementValue("Adress", param.Adress);

                xml.Save(_basePath);

                Result = true;
            }
            return Result;
        }
        /*
         * 删除ID为contactid的信息
         */
        public static bool DeleteContactInfo(int contactid)
        {
            bool Result = false;
            if (contactid > 0)
            {
                XElement xml = XElement.Load(_basePath);
                XElement contactXml =
                    (
                        from db
                        in xml.Descendants("contact")
                        where db.Attribute("ContactId").Value == contactid.ToString()
                        select db
                    ).Single();
                contactXml.Remove();
                xml.Save(_basePath);
                Result = true;
            }
            return Result;
        }
        /*
         * 替换文件信息 _BackUpPath内容替换成_BasePath中的内容
         * _Base to _BacuUp
         */
        public static bool ChangeXml(string _BasePath, string _BackUpPath)
        {
            bool Result = false;
            XElement xmlNew = XElement.Load(_BasePath);
            XElement xmlBackUp = XElement.Load(_BackUpPath);
            //把xmlBackUp里的数据替换成xmlNew
            xmlBackUp.ReplaceAll(
                from db
                in xmlNew.Descendants("contact")
                select db
                );
            //保存
            xmlBackUp.Save(_BackUpPath);

            Result = true;
            return Result;
        }

    }
}
