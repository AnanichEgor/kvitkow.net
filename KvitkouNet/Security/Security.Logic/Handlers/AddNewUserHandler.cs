using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Security.Data;
using Security.Data.Models;
using Security.Logic.Models.Requests;

namespace Security.Logic.Handlers
{
    public class AddNewUserHandler : IRequestHandler<AddNewUserRequest, bool>
    {
        private ISecurityData _securityData;
        private IMapper _mapper;

        public AddNewUserHandler(ISecurityData securityData, IMapper mapper)
        {
            _securityData = securityData;
            _mapper = mapper;
        }

        public Task<bool> Handle(AddNewUserRequest request, CancellationToken cancellationToken)
        {
            return _securityData.AddUser(_mapper.Map<UserInfoDb>(request.UserInfo));
        }
    }
}
