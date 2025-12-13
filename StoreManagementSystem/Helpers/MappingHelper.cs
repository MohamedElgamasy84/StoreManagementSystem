using StoreManagementSystem.ViewModels;

namespace StoreManagementSystem.Helpers
{
    public class MappingHelper
    {
        public static ProductUpdateViewModel ToUpdatePRViewModel(ProductDetailViewModel vm)
        {
            return new ProductUpdateViewModel
            {
                Id = vm.Id,
                Name = vm.Name,
                Units = vm.Units.Select(vm=> new ProductUnitUpdateViewModel
                {
                    UnitName = vm.UnitName,
                    UnitId = vm.UnitId

                }).ToList(),
                CostPrice = vm.CostPrice,
               
                ImageName = vm.ImageName,
                CategoryId = vm.CategoryId
            };
        }
        public static CategoryUpdateViewModel ToUpdateCGViewModel(CategoryViewModel vm)
        {
            return new CategoryUpdateViewModel
            {
                Id = vm.Id,
                Name = vm.Name
            };
        }
        //public static CustomerCreateUpViewModel ToCustomerUpdateViewModel(CustomerViewModel vm)
        //{
        //    return new CustomerCreateUpViewModel
        //    {
        //        Id = vm.Id,
        //        FullName = vm.FullName,
        //        PhoneNumber = vm.PhoneNumber
        //    };
        //}
        //public static SupplierCreateViewModel ToSupplierUpdateViewModel(SupplierViewModel vm)
        //{
        //    return new SupplierCreateViewModel
        //    {
        //        Id = vm.Id,
        //        FullName = vm.FullName,
        //        PhoneNumber = vm.PhoneNumber,
        //        Email = vm.Email
        //    };
        //}
    }
}
