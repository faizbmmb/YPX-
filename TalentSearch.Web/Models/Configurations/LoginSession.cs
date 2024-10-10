namespace TalentSearch.Web.Models.Configurations
{
    public class LoginSession
    {
        private static IHttpContextAccessor _HttpContextAccessor;
        private static ISession _Session;

        public LoginSession(ISession session)//IHttpContextAccessor httpContextAccessor)
        {
            //_HttpContextAccessor = httpContextAccessor;
            //_Session = _HttpContextAccessor.HttpContext.Session;
            _Session = session;
        }

        private static string _userID = "_UserID";
        private static string _userName = "_userName";
        private static string _userDisplayName = "_UserDisplayName";
        private static string _userIdentity = "_userIdentity";
        private static string _userAvatar = "_userAvatar";
        private static string _userEmail = "_userEmail";
        private static string _CurrentPage = "_CurrentPage";
        private static string _CurrentPageIcon = "_CurrentPageIcon";
        private static string _userRole = "_userRole";

        public static void Reset()
        {
            UserID = null;
            //UserDisplayName = null;
            //UserAvatar = null;
            //UserEmail = null;
        }

        public static string UserID
        {
            get
            {
                if (_Session.GetString(_userID) == null)
                { return string.Empty; }
                else
                { return _Session.GetString(_userID).ToString(); }
            }
            set
            { _Session.SetString(_userID, value); }
        }

        public static string UserName
        {
            get
            {
                if (_Session.GetString(_userName) == null)
                { return string.Empty; }
                else
                { return _Session.GetString(_userName).ToString(); }
            }
            set
            { _Session.SetString(_userName, value); }
        }


        public static string UserIdentity
        {
            get
            {
                if (_Session.GetString(_userName) == null)
                { return string.Empty; }
                else
                { return _Session.GetString(_userIdentity).ToString(); }
            }
            set
            { _Session.SetString(_userIdentity, value); }
        }

        public static string UserDisplayName
        {
            get
            {
                if (_Session.GetString(_userDisplayName) == null)
                { return string.Empty; }
                else
                { return _Session.GetString(_userDisplayName).ToString(); }
            }
            set
            { _Session.SetString(_userDisplayName, value); }
        }

        public static string UserAvatar
        {
            get
            {
                if (_Session.GetString(_userAvatar) == null)
                { return string.Empty; }
                else
                { return _Session.GetString(_userAvatar).ToString(); }
            }
            set
            { _Session.SetString(_userAvatar, value); }
        }

        public static string UserEmail
        {
            get
            {
                if (_Session.GetString(_userEmail) == null)
                { return string.Empty; }
                else
                { return _Session.GetString(_userEmail).ToString(); }
            }
            set
            { _Session.SetString(_userEmail, value); }
        }

        public static string UserRole
        {
            get
            {
                if (_Session.GetString(_userRole) == null)
                { return string.Empty; }
                else
                { return _Session.GetString(_userRole).ToString(); }
            }
            set
            { _Session.SetString(_userRole, value); }
        }

        public static string CurrentPage
        {
            get
            {
                if (_Session.GetString(_CurrentPage) == null)
                { return string.Empty; }
                else
                { return _Session.GetString(_CurrentPage).ToString(); }
            }
            set
            { _Session.SetString(_CurrentPage, value); }
        }

        public static string CurrentPageIcon
        {
            get
            {
                if (_Session.GetString(_CurrentPageIcon) == null)
                { return string.Empty; }
                else
                { return _Session.GetString(_CurrentPageIcon).ToString(); }
            }
            set
            { _Session.SetString(_CurrentPageIcon, value); }
        }

        public static bool CheckRole(string RoleName)
        {
            if (_Session.GetString(_CurrentPageIcon).ToLower().Contains(RoleName.ToLower())) return true;
            else return false;
        }
    }
}