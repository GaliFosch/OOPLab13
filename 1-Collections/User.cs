using System;

namespace Collections
{
    public class User : IUser
    {
        public User(string fullName, string username, uint? age)
        {
            if(fullName == null) throw new ArgumentNullException("fullName==NULL");
            if(username == null) throw new ArgumentNullException("fullName==NULL");
            FullName = fullName;
            Username = username;
            Age = age;
        }
        
        public uint? Age { get; }
        
        public string FullName { get; }
        
        public string Username { get; }

        public bool IsAgeDefined => Age!=null;

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Age == user.Age &&
                   FullName == user.FullName &&
                   Username == user.Username &&
                   IsAgeDefined == user.IsAgeDefined;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Age, FullName, Username, IsAgeDefined);
        }

        // TODO implement missing methods (try to autonomously figure out which are the necessary methods)

    }
}
