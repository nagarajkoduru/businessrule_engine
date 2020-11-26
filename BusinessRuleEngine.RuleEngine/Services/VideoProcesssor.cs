using BusinessRuleEngine.RuleEngine.Models;
using BusinessRuleEngine.RuleEngine.Models.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRuleEngine.RuleEngine.Services
{
    public class VideoProcesssor : OrderProcess<ProductDetails>
    {
        protected override PaymentResult ProcessOrder(ProductDetails model)
        {
            if (!string.IsNullOrEmpty(model.Description))
            {
                if (model.Description.ToLowerInvariant() == Labels.VIDEO_TITLE_FOR_CHECK)
                {
                    return new PaymentResult
                    {
                        IsSuccess = true,
                        Message = "Added First Aid video to the packing slip."
                    };
                }
                else
                {
                    return new PaymentResult
                    {
                        IsSuccess = true,
                        Message = "Generated Packing slip"
                    };
                }
            }
            else
            {
                throw new InvalidOperationException("Video Descrption is missing");
            }
        }
    }
}
