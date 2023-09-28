using AdessoLeague.Model;
using FluentValidation;

namespace AdessoLeague.Validator
{
    public class GroupCreateRequestModelValidator : AbstractValidator<GroupCreateRequestModel>
    {
        public GroupCreateRequestModelValidator()
        {
            RuleFor(m => m.CreatorId).GreaterThan(0).WithMessage("Kurayı Çeken Kişinin Kullanıcı Id Değeri 0 dan Büyük Olmalıdır");
            RuleFor(m => m.CreatorName).NotEmpty().WithMessage("Kurayı Çeken Kişinin İsmi Boş Olamaz");
            RuleFor(m => m.CreatorSurname).NotEmpty().WithMessage("Kurayı Çeken Kişinin Soyismi Boş Olamaz");
            RuleFor(m => m.GroupCount).Must(m => m == 4 || m == 8).WithMessage("Grup Sayısı 4 veya 8 Olabilir");
        }
    }
}
