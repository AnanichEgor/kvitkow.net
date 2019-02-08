using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Security.Data;
using Security.Data.Models;
using Security.Logic.Models.Requests;

namespace Security.Logic.Handlers
{
    public class ChangeUserHandler : IRequestHandler<ChangeUserRequest, bool>
    {
        private ISecurityData _securityData;
        private IMapper _mapper;

        public ChangeUserHandler(ISecurityData securityData, IMapper mapper)
        {
            _securityData = securityData;
            _mapper = mapper;
        }

        public Task<bool> Handle(ChangeUserRequest request, CancellationToken cancellationToken)
        {
            return _securityData.UpdateUser(_mapper.Map<UserInfoDb>(request.UserInfo));
        }
    }
}
