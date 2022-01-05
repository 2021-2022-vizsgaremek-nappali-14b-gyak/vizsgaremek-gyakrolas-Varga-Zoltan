using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace Vizsgaremek.Models
{
    public class ProgramInfo
    {
        private Version version;
        private string authors;
        private string title;
        private string description;
        private string company;

        public Version Version
        {
            get
            {
                var assembly = Assembly.GetExecutingAssembly();
                var assemblyVerzio = assembly.GetName().Version;
                return assemblyVerzio;
            }
        }

        public string Authors
        {
            get
            {
                return authors;
            }
        }

        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Company { get => company; set => company = value; }

        public ProgramInfo()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();


            foreach (Attribute attr in Attribute.GetCustomAttributes(assembly))
            {
                if (attr.GetType() == typeof(AssemblyTitleAttribute))
                    title = ((AssemblyTitleAttribute)attr).Title;
                else if (attr.GetType() == typeof(AssemblyDescriptionAttribute))
                    description = ((AssemblyDescriptionAttribute)attr).Description;
                else if (attr.GetType() == typeof(AssemblyCompanyAttribute))
                    company = ((AssemblyCompanyAttribute)attr).Company;
               // else if (attr.GetType() == typeof(AssemblyCompanyAttribute))
                 //   authors = ((AssemblyCompanyAttribute)attr).//Authors;

            }

        }

        public ProgramInfo(string authors, string title, string description, string company)
        {
            this.authors = authors;
            this.title = title;
            this.description = description;
            this.company = company;
        }
    }
}
