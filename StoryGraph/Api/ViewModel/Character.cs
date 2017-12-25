using System;
using System.Linq;
using KVP.StoryGraph.Utility;

namespace KVP.StoryGraph.Api.ViewModel
{
    public class Character : Entity
    {
        public string FirstName => NameList().Any() ? NameList().First() : null;
        public string LastName => NameCount() > 1 ? NameList().Last() : null;
        public string MiddleNname => NameCount() > 2 ? NameList().Skip(1).Take(NameCount() - 2).Join() : null;

        public DateTime Birth => Creation;
        public DateTime? Death => Destruction;

        private string[] NameList() => Name.IsNullOrEmpty() ? new string[0] : Name.Split(" ");
        private int NameCount() => NameList().Length;
    }
}