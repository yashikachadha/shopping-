

namespace CartDataAccessLayer
{
    /// <summary>
    /// class defining attributes of the user
    /// </summary>
    public class User
    {
        #region public properties
        /// <summary>
        /// set unique userId for each user
        /// </summary>
        public int userId { get; set; }
        /// <summary>
        /// get set username 
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// get set password
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// get set confirm password
        /// </summary>
        public string cpass { get; set; }

        /// <summary>
        /// get set address of user
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// get set gender of user
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        /// get set phone number of user
        /// </summary>
        public string phone { get; set; }
        #endregion
    }
}
