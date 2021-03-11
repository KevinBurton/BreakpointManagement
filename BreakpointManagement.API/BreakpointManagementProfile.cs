using AutoMapper;
using BreakpointManagement.Data.Models;
using BreakpointManagement.Shared.Models;

namespace BreakpointManagement.API
{
	public class BreakpointManagementProfile : Profile
	{
		public BreakpointManagementProfile()
		{
			CreateMap<TblBreakpoint, Breakpoint>();
			CreateMap<TblBreakpointException, BreakpointException>();
			CreateMap<TblBreakpointgroup, Breakpointgroup>();
			CreateMap<TblBreakpointHistory, BreakpointHistory>();
			CreateMap<TblBreakpointInferred, BreakpointInferred>();
			CreateMap<TblBreakpointStandard, BreakpointStandard>();
			CreateMap<TblDrug, Drug>();
			CreateMap<TblDrugClass, DrugClass>()
								.ForSourceMember(source => source.TblDrugSubclasses, opt => opt.DoNotValidate());
			CreateMap<TblDrugSubclass, DrugSubclass>()
								.ForSourceMember(source => source.TblDrugs, opt => opt.DoNotValidate());
			CreateMap<TblOrganismFamily, OrganismFamily>()
								.ForSourceMember(source => source.TblOrganismSubfamilies, opt => opt.DoNotValidate());
			CreateMap<TblOrganismFamilyLanguage, OrganismFamilyLanguage>();
			CreateMap<TblOrganismGenus, OrganismGenus>();
			CreateMap<TblOrganismName, OrganismName>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.OrganismName));
			CreateMap<TblOrganismNameLanguage, OrganismNameLanguage>();
			CreateMap<TblOrganismSubfamily, OrganismSubfamily>()
								.ForSourceMember(source => source.OrganismFamily, opt => opt.DoNotValidate());
			CreateMap<TblOrganismSubfamilyLanguage, OrganismSubfamilyLanguage>();
		}
	}
}
