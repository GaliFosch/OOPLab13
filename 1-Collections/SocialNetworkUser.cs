using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private Dictionary<string,List<TUser>> _groups = new Dictionary<string, List<TUser>>();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
        }

        public bool AddFollowedUser(string group, TUser user)
        {
            List<TUser> gl;
            if(_groups.TryGetValue(group,out gl)){
                if(gl.Contains(user))
                    return false;
                gl.Add(user);
            }else{
                gl = new List<TUser>();
                gl.Add(user);
                _groups.Add(group,gl);
            }
            return true;
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                List<TUser> ret = new List<TUser>();
                foreach(var item in _groups)
                {
                    foreach(var user in item.Value){
                        if(!ret.Contains(user)) ret.Add(user);
                    }
                }
                return ret;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            List<TUser> gl;
            if(!_groups.TryGetValue(group, out gl)) gl = new List<TUser>();
            return gl;
        }
    }
}
