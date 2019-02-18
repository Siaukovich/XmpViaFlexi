using System.Security.Authentication;
using System.Threading.Tasks;

namespace VacationsTracker.Core.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly ISecureStorage _storage;

        public UserRepository(ISecureStorage storage)
        {
            _storage = storage;
        }

        public async Task AuthorizeAsync(string login, string password)
        {
            if (login != "a" || password != "b")
            {
                throw new AuthenticationException();
            }

            var token = "eyJhbGciOiJSUzI1NiIsImtpZCI6ImEyNmQyNGY2NTYyMzVhNjcxZmNlMzBmZmNiN2UwNmMzIiwidHlwIjoiSldUIn0.eyJuYmYiOjE1NTA1MjI1MTEsImV4cCI6MTU1MDUyNjExMSwiaXNzIjoiaHR0cHM6Ly92dHMtdG9rZW4taXNzdWVyLXYyLmF6dXJld2Vic2l0ZXMubmV0IiwiYXVkIjpbImh0dHBzOi8vdnRzLXRva2VuLWlzc3Vlci12Mi5henVyZXdlYnNpdGVzLm5ldC9yZXNvdXJjZXMiLCJWVFMtU2VydmVyLXYyIl0sImNsaWVudF9pZCI6IlZUUy1Td2FnZ2VyLXYxIiwic3ViIjoiMSIsImF1dGhfdGltZSI6MTU1MDUxODIzNywiaWRwIjoibG9jYWwiLCJzY29wZSI6WyJWVFMtU2VydmVyLXYyIl0sImFtciI6WyJwd2QiXX0.GYp7VgsvNezXF8pdISDbSPP-9HRLafXDfeea585QkwZjUX9tjAiw7rGG28KE1Z1aHTLoWntqSgzTlDgI6rvBa-UMgpF3lmBrfVnfzRNIMgTUhdxXSzblndoYU-eCnE-TzYq-xq-WVBkOvVQSertJTAc3X1vI3KXawikhrjl_MHdFCy4uN9ZUJEerObgqBZAIIVQQEs0NkRgKwmKD52UbgWCR543kZHiQESx6TeMJS65bkjs0oFWu-F7GQjVUJTys4KtKzVEqW5SFqitf3XN4cVIa_y2wJWr2Ol_nWX_DxZbAhKVeNl-349VjE_kvxY0LKAxU9nIkDlGeKwH_nrZ0og";
            await _storage.SetAsync("id_token", token);
        }
    }
}