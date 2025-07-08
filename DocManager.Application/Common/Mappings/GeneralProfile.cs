using AutoMapper;
using DocManager.Application.Commands.CustomField;
using DocManager.Application.Commands.Document;
using DocManager.Application.Commands.Expediente;
using DocManager.Application.Commands.ExpedienteType;
using DocManager.Domain.Entities;

namespace DocManager.Application.Common.Mappings;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        //Map commands
        CreateMap<CreateExpedienteTypeCommand, ExpedienteType>().ReverseMap();
        CreateMap<CreateDocumentCommand, Document>().ReverseMap();
        CreateMap<CreateExpedienteCommand, Expediente>()
            .ForMember(dest => dest.ExpedienteTypeId, src => src.MapFrom(s => s.ExpedienteTypeId))
            .ForMember(dest => dest.FieldValues, src => 
                    src.MapFrom(s => s.FieldValues
                        .Select(fv => new FieldValue
                        {
                             CustomFieldId = fv.CustomFieldId,
                             ExpedienteId = s.ExpedienteTypeId,
                             Value = fv.Value
                        })
                    )
            );
        CreateMap<CreateCustomFieldCommand, CustomField>()
            .ForMember(dest => dest.ExpedienteTypeId, opt => opt.MapFrom(src => src.ExpedienteTypeId))
            .ForMember(dest => dest.FieldName, opt => opt.MapFrom(src => src.FieldName))
            .ForMember(dest => dest.DataType, opt => opt.MapFrom(src => src.DataType))
            .ForMember(dest => dest.IsRequired, opt => opt.MapFrom(src => src.IsRequired))
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Order))
            .ForMember(dest => dest.Options, opt =>
                opt.MapFrom(src => src.Options
                    .Select(o => new FieldListOption
                    {
                        OptionValue = o.OptionValue,
                        CustomFieldId = o.CustomFieldId
                    })
                )
            );
    }
}
