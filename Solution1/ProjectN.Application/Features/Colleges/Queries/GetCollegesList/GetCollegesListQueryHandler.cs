using AutoMapper;
using MediatR;
using ProjectN.Application.Contracts.Persistance;
using ProjectN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectN.Application.Features.Colleges.Queries.GetCollegesList
{
    public class GetCollegesListQueryHandler : IRequestHandler<GetCollegesListQuery, List<CollegeListVm>>
    {
        private readonly IAsyncRepository<College> _collegeRepositiry;
        private readonly IMapper _mapper;
        public GetCollegesListQueryHandler(IMapper mapper, IAsyncRepository<College> collegeRepository)
        {
            _mapper = mapper;
            _collegeRepositiry = collegeRepository;
        }

        public async Task<List<CollegeListVm>> Handle(GetCollegesListQuery request, CancellationToken cancellationToken)
        {
            var allColleges = await _collegeRepositiry.ListAllAsync();
            try
            {
                return _mapper.Map<List<CollegeListVm>>(allColleges);
            }
            catch(Exception e)
            {
                throw;
            }

        }
    }
}
