using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ChargeBee.Internal;
using ChargeBee.Api;
using ChargeBee.Models.Enums;

namespace ChargeBee.Models
{

    public class Estimate : Resource 
    {
    

        #region Methods
        public static CreateSubscriptionRequest CreateSubscription()
        {
            string url = ApiUtil.BuildUrl("estimates", "create_subscription");
            return new CreateSubscriptionRequest(url, HttpMethod.POST);
        }
        public static UpdateSubscriptionRequest UpdateSubscription()
        {
            string url = ApiUtil.BuildUrl("estimates", "update_subscription");
            return new UpdateSubscriptionRequest(url, HttpMethod.POST);
        }
        public static RenewalEstimateRequest RenewalEstimate(string id)
        {
            string url = ApiUtil.BuildUrl("subscriptions", CheckNull(id), "renewal_estimate");
            return new RenewalEstimateRequest(url, HttpMethod.GET);
        }
        #endregion
        
        #region Properties
        public DateTime CreatedAt 
        {
            get { return (DateTime)GetDateTime("created_at", true); }
        }
        public bool Recurring 
        {
            get { return GetValue<bool>("recurring", true); }
        }
        public string SubscriptionId 
        {
            get { return GetValue<string>("subscription_id", false); }
        }
        public SubscriptionStatusEnum? SubscriptionStatus 
        {
            get { return GetEnum<SubscriptionStatusEnum>("subscription_status", false); }
        }
        public DateTime? TermEndsAt 
        {
            get { return GetDateTime("term_ends_at", false); }
        }
        public bool CollectNow 
        {
            get { return GetValue<bool>("collect_now", true); }
        }
        public int Amount 
        {
            get { return GetValue<int>("amount", true); }
        }
        public PriceTypeEnum PriceType 
        {
            get { return GetEnum<PriceTypeEnum>("price_type", true); }
        }
        public int SubTotal 
        {
            get { return GetValue<int>("sub_total", true); }
        }
        public List<EstimateLineItem> LineItems 
        {
            get { return GetResourceList<EstimateLineItem>("line_items"); }
        }
        public List<EstimateDiscount> Discounts 
        {
            get { return GetResourceList<EstimateDiscount>("discounts"); }
        }
        public List<EstimateTax> Taxes 
        {
            get { return GetResourceList<EstimateTax>("taxes"); }
        }
        
        #endregion
        
        #region Requests
        public class CreateSubscriptionRequest : EntityRequest<CreateSubscriptionRequest> 
        {
            public CreateSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public CreateSubscriptionRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.AddOpt("subscription[id]", subscriptionId);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.Add("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public CreateSubscriptionRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public CreateSubscriptionRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public CreateSubscriptionRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public CreateSubscriptionRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public CreateSubscriptionRequest CustomerTaxability(TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public CreateSubscriptionRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public CreateSubscriptionRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
        }
        public class UpdateSubscriptionRequest : EntityRequest<UpdateSubscriptionRequest> 
        {
            public UpdateSubscriptionRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public UpdateSubscriptionRequest BillingCycles(int billingCycles) 
            {
                m_params.AddOpt("billing_cycles", billingCycles);
                return this;
            }
            public UpdateSubscriptionRequest ReplaceAddonList(bool replaceAddonList) 
            {
                m_params.AddOpt("replace_addon_list", replaceAddonList);
                return this;
            }
            public UpdateSubscriptionRequest Prorate(bool prorate) 
            {
                m_params.AddOpt("prorate", prorate);
                return this;
            }
            public UpdateSubscriptionRequest EndOfTerm(bool endOfTerm) 
            {
                m_params.AddOpt("end_of_term", endOfTerm);
                return this;
            }
            public UpdateSubscriptionRequest IncludeDelayedCharges(bool includeDelayedCharges) 
            {
                m_params.AddOpt("include_delayed_charges", includeDelayedCharges);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionId(string subscriptionId) 
            {
                m_params.Add("subscription[id]", subscriptionId);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanId(string subscriptionPlanId) 
            {
                m_params.AddOpt("subscription[plan_id]", subscriptionPlanId);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionPlanQuantity(int subscriptionPlanQuantity) 
            {
                m_params.AddOpt("subscription[plan_quantity]", subscriptionPlanQuantity);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionStartDate(long subscriptionStartDate) 
            {
                m_params.AddOpt("subscription[start_date]", subscriptionStartDate);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionTrialEnd(long subscriptionTrialEnd) 
            {
                m_params.AddOpt("subscription[trial_end]", subscriptionTrialEnd);
                return this;
            }
            public UpdateSubscriptionRequest SubscriptionCoupon(string subscriptionCoupon) 
            {
                m_params.AddOpt("subscription[coupon]", subscriptionCoupon);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressCountry(string billingAddressCountry) 
            {
                m_params.AddOpt("billing_address[country]", billingAddressCountry);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressStateCode(string billingAddressStateCode) 
            {
                m_params.AddOpt("billing_address[state_code]", billingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionRequest BillingAddressZip(string billingAddressZip) 
            {
                m_params.AddOpt("billing_address[zip]", billingAddressZip);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressCountry(string shippingAddressCountry) 
            {
                m_params.AddOpt("shipping_address[country]", shippingAddressCountry);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressStateCode(string shippingAddressStateCode) 
            {
                m_params.AddOpt("shipping_address[state_code]", shippingAddressStateCode);
                return this;
            }
            public UpdateSubscriptionRequest ShippingAddressZip(string shippingAddressZip) 
            {
                m_params.AddOpt("shipping_address[zip]", shippingAddressZip);
                return this;
            }
            public UpdateSubscriptionRequest CustomerVatNumber(string customerVatNumber) 
            {
                m_params.AddOpt("customer[vat_number]", customerVatNumber);
                return this;
            }
            public UpdateSubscriptionRequest CustomerTaxability(TaxabilityEnum customerTaxability) 
            {
                m_params.AddOpt("customer[taxability]", customerTaxability);
                return this;
            }
            public UpdateSubscriptionRequest AddonId(int index, string addonId) 
            {
                m_params.AddOpt("addons[id][" + index + "]", addonId);
                return this;
            }
            public UpdateSubscriptionRequest AddonQuantity(int index, int addonQuantity) 
            {
                m_params.AddOpt("addons[quantity][" + index + "]", addonQuantity);
                return this;
            }
        }
        public class RenewalEstimateRequest : EntityRequest<RenewalEstimateRequest> 
        {
            public RenewalEstimateRequest(string url, HttpMethod method) 
                    : base(url, method)
            {
            }

            public RenewalEstimateRequest IncludeDelayedCharges(bool includeDelayedCharges) 
            {
                m_params.AddOpt("include_delayed_charges", includeDelayedCharges);
                return this;
            }
        }
        #endregion

        public enum PriceTypeEnum
        {

            UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
            dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
            [Description("tax_exclusive")]
            TaxExclusive,
            [Description("tax_inclusive")]
            TaxInclusive,

        }

        #region Subclasses
        public class EstimateLineItem : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("charge")]
                Charge,
                [Description("prorated_charge")]
                ProratedCharge,
                [Description("setup_charge")]
                SetupCharge,
            }
            public enum EntityTypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("plan")]
                Plan,
                [Description("addon")]
                Addon,
                [Description("adhoc")]
                Adhoc,
            }

            public DateTime DateFrom() {
                return (DateTime)GetDateTime("date_from", true);
            }

            public DateTime DateTo() {
                return (DateTime)GetDateTime("date_to", true);
            }

            public int UnitAmount() {
                return GetValue<int>("unit_amount", true);
            }

            public int? Quantity() {
                return GetValue<int?>("quantity", false);
            }

            public bool IsTaxed() {
                return GetValue<bool>("is_taxed", true);
            }

            public int? Tax() {
                return GetValue<int?>("tax", false);
            }

            public double? TaxRate() {
                return GetValue<double?>("tax_rate", false);
            }

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", true);
            }

            public TypeEnum LineItemType() {
                return GetEnum<TypeEnum>("type", true);
            }

            public EntityTypeEnum EntityType() {
                return GetEnum<EntityTypeEnum>("entity_type", true);
            }

            public string EntityId() {
                return GetValue<string>("entity_id", false);
            }

        }
        public class EstimateDiscount : Resource
        {
            public enum TypeEnum
            {
                UnKnown, /*Indicates unexpected value for this enum. You can get this when there is a
                dotnet-client version incompatibility. We suggest you to upgrade to the latest version */
                [Description("coupon")]
                Coupon,
                [Description("credit_adjustment")]
                CreditAdjustment,
                [Description("account_credits")]
                AccountCredits,
            }

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

            public TypeEnum DiscountType() {
                return GetEnum<TypeEnum>("type", true);
            }

            public string EntityId() {
                return GetValue<string>("entity_id", false);
            }

        }
        public class EstimateTax : Resource
        {

            public int Amount() {
                return GetValue<int>("amount", true);
            }

            public string Description() {
                return GetValue<string>("description", false);
            }

        }

        #endregion
    }
}
