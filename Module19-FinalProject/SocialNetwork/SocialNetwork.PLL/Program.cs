using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;

namespace SocialNetwork.PLL
{
    class Program
    {
        static MessageService _messageService;
        static UserService _userService;
        public static MainView _mainView;
        public static RegistrationView _registrationView;
        public static AuthenticationView _authenticationView;
        public static UserMenuView _userMenuView;
        public static UserInfoView _userInfoView;
        public static UserDataUpdateView _userDataUpdateView;
        public static MessageSendingView _messageSendingView;
        public static UserIncomingMessageView _userIncomingMessageView;
        public static UserOutcomingMessageView _userOutcomingMessageView;
        public static AddFriendView _addFriendView;

        static void Main(string[] args)
        {
            _userService = new UserService();
            _messageService = new MessageService();

            _mainView = new MainView();
            _registrationView = new RegistrationView(_userService);
            _authenticationView = new AuthenticationView(_userService);
            _userMenuView = new UserMenuView(_userService);
            _userInfoView = new UserInfoView();
            _userDataUpdateView = new UserDataUpdateView(_userService);
            _messageSendingView = new MessageSendingView(_messageService, _userService);
            _userIncomingMessageView = new UserIncomingMessageView();
            _userOutcomingMessageView = new UserOutcomingMessageView();
            _addFriendView = new AddFriendView(_userService);

            while (true)
            {
                _mainView.Show();
            }
        }
    }
}
