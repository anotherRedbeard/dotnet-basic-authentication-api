namespace WebApi.Services;

using WebApi.Entities;

public interface IUserService
{
    Task<User> Authenticate(string username, string password);
    Task<IEnumerable<User>> GetAll();
    Task<User> CreateUser(string firstName, string lastName, string username, string password);
    Task<User> DeleteUser(string username);
}

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<User> _users = new List<User>
    {
        new User { Id = 1, FirstName = "Test", LastName = "User1", Username = "test1", Password = "test" }
    };

    public async Task<User> Authenticate(string username, string password)
    {
        // wrapped in "await Task.Run" to mimic fetching user from a db
        var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

        // on auth fail: null is returned because user is not found
        // on auth success: user object is returned
        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        // wrapped in "await Task.Run" to mimic fetching users from a db
        return await Task.Run(() => _users);
    }

    public async Task<User> CreateUser(string firstName, string lastName, string userName, string password)
    {
        // wrapped in "await Task.Run" to mimic fetching users from a db
        //create new user object
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Username = userName,
            Password = password
        };
        //set user id to next available id
        user.Id = _users.Max(x => x.Id) + 1;
        //add user to list
        _users.Add(user);
        //return newly created user from list
        return await Task.Run(() => _users.SingleOrDefault(x => x.Username == user.Username));
    }

    public async Task<User> DeleteUser(string username)
    {
        // wrapped in "await Task.Run" to mimic fetching users from a db
        //find user in list
        var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username));
        //remove user from list
        _users.Remove(user);
        //return deleted user
        return user;
    }
}
