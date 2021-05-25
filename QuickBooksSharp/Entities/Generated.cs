using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace QuickBooksSharp.Entities
{
    public enum AcquiredAsEnum
    {
        Unspecified = 0,
        New,
        Used,
    }
    public enum MonthEnum
    {
        Unspecified = 0,
        January,
        February,
        March,
        April,
        May,
        June,
        July,
        August,
        September,
        October,
        November,
        December,
    }
    public enum WeekEnum
    {
        Unspecified = 0,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
    }
    public enum UOMFeatureTypeEnum
    {
        Unspecified = 0,
        Disabled,
        SinglePerItem,
        MultiplePerItem,
    }
    public enum AccountClassificationEnum
    {
        Unspecified = 0,
        Asset,
        Equity,
        Expense,
        Liability,
        Revenue,
    }
    public enum ItemTypeEnum
    {
        Unspecified = 0,
        Assembly,
        Category,
        [EnumMember(Value = "Fixed Asset")]
        FixedAsset,
        Group,
        Inventory,
        NonInventory,
        [EnumMember(Value = "Other Charge")]
        OtherCharge,
        Payment,
        Service,
        Subtotal,
        Discount,
        Tax,
        [EnumMember(Value = "Tax Group")]
        TaxGroup,
        Bundle,
    }
    public enum CustomerTypeEnum
    {
        Unspecified = 0,
        Customer,
        Job,
    }
    public enum BillableStatusEnum
    {
        Unspecified = 0,
        Billable,
        NotBillable,
        HasBeenBilled,
    }
    public enum TaxFormTypeEnum
    {
        Unspecified = 0,
        [EnumMember(Value = "Form C")]
        FormC,
        [EnumMember(Value = "Form F")]
        FormF,
        [EnumMember(Value = "Form I")]
        FormI,
        [EnumMember(Value = "Form H")]
        FormH,
        [EnumMember(Value = "Form E1")]
        FormE1,
        [EnumMember(Value = "Form E2")]
        FormE2,
    }
    public enum EntityTypeEnum
    {
        Unspecified = 0,
        Customer,
        Employee,
        Job,
        Other,
        Vendor,
    }
    public enum TaxApplicableOnEnum
    {
        Unspecified = 0,
        Purchase,
        Sales,
    }
    public enum PostingTypeEnum
    {
        Unspecified = 0,
        Credit,
        Debit,
    }
    public enum LineDetailTypeEnum
    {
        Unspecified = 0,
        PaymentLineDetail,
        DiscountLineDetail,
        TaxLineDetail,
        SalesItemLineDetail,
        ItemBasedExpenseLineDetail,
        AccountBasedExpenseLineDetail,
        DepositLineDetail,
        PurchaseOrderItemLineDetail,
        ItemReceiptLineDetail,
        JournalEntryLineDetail,
        GroupLineDetail,
        DescriptionOnly,
        SubTotalLineDetail,
        SalesOrderItemLineDetail,
        TDSLineDetail,
        ReimburseLineDetail,
    }
    public enum AccountTypeEnum
    {
        Unspecified = 0,
        Bank,
        [EnumMember(Value = "Accounts Receivable")]
        AccountsReceivable,
        [EnumMember(Value = "Other Current Asset")]
        OtherCurrentAsset,
        [EnumMember(Value = "Fixed Asset")]
        FixedAsset,
        [EnumMember(Value = "Other Asset")]
        OtherAsset,
        [EnumMember(Value = "Accounts Payable")]
        AccountsPayable,
        [EnumMember(Value = "Credit Card")]
        CreditCard,
        [EnumMember(Value = "Other Current Liability")]
        OtherCurrentLiability,
        [EnumMember(Value = "Long Term Liability")]
        LongTermLiability,
        Equity,
        Income,
        [EnumMember(Value = "Cost of Goods Sold")]
        CostofGoodsSold,
        Expense,
        [EnumMember(Value = "Other Income")]
        OtherIncome,
        [EnumMember(Value = "Other Expense")]
        OtherExpense,
        [EnumMember(Value = "Non-Posting")]
        NonPosting,
    }
    public enum TaxRateDisplayTypeEnum
    {
        Unspecified = 0,
        ReadOnly,
        HideInTransactionForms,
        HideInPrintedForms,
        HideInAll,
    }
    public enum AccountSubTypeEnum
    {
        Unspecified = 0,
        IncomeTaxPayable,
        IntangibleAssetsOther,
        AccountsPayable,
        AccountsReceivable,
        AccumulatedAdjustment,
        AccumulatedAmortization,
        AccumulatedAmortizationOfOtherAssets,
        AccumulatedDepletion,
        AccumulatedDepreciation,
        AdvertisingPromotional,
        AllowanceForBadDebts,
        Amortization,
        Auto,
        BadDebts,
        BankCharges,
        Buildings,
        CashOnHand,
        CharitableContributions,
        Checking,
        CommonStock,
        CostOfLabor,
        CostOfLaborCos,
        CreditCard,
        DepletableAssets,
        Depreciation,
        DevelopmentCosts,
        DirectDepositPayable,
        DiscountsRefundsGiven,
        DividendIncome,
        DuesSubscriptions,
        EmployeeCashAdvances,
        Entertainment,
        EntertainmentMeals,
        EquipmentRental,
        EquipmentRentalCos,
        EstimatedTaxes,
        ExchangeGainOrLoss,
        FederalIncomeTaxPayable,
        FinanceCosts,
        FixedAssetComputers,
        FixedAssetCopiers,
        FixedAssetFurniture,
        FixedAssetPhone,
        FixedAssetPhotoVideo,
        FixedAssetSoftware,
        FixedAssetOtherToolsEquipment,
        FurnitureAndFixtures,
        GlobalTaxExpense,
        GlobalTaxPayable,
        GlobalTaxSuspense,
        GasAndFuel,
        Goodwill,
        Gratuity,
        Healthcare,
        HomeOffice,
        HomeownerRentalInsurance,
        Insurance,
        InsurancePayable,
        IntangibleAssets,
        InterestEarned,
        InterestPaid,
        Inventory,
        Investment_MortgageRealEstateLoans,
        Investment_Other,
        Investment_TaxExemptSecurities,
        Investment_USGovernmentObligations,
        Land,
        LeaseBuyout,
        LeaseholdImprovements,
        LegalProfessionalFees,
        Licenses,
        LineOfCredit,
        LoanPayable,
        LoansToOfficers,
        LoansToOthers,
        LoansToStockholders,
        MachineryAndEquipment,
        MoneyMarket,
        MortgageInterestHomeOffice,
        NonProfitIncome,
        NotesPayable,
        OfficeGeneralAdministrativeExpenses,
        OpeningBalanceEquity,
        OrganizationalCosts,
        OtherBusinessExpenses,
        OtherCostsOfServiceCos,
        OtherCurrentAssets,
        OtherCurrentLiabilities,
        OtherFixedAssets,
        OtherHomeOfficeExpenses,
        OtherInvestmentIncome,
        OtherLongTermAssets,
        OtherLongTermLiabilities,
        OtherMiscellaneousExpense,
        OtherMiscellaneousIncome,
        OtherMiscellaneousServiceCost,
        OtherPrimaryIncome,
        OtherVehicleExpenses,
        OwnersEquity,
        PaidInCapitalOrSurplus,
        ParkingAndTolls,
        PartnerContributions,
        PartnerDistributions,
        PartnersEquity,
        PayrollClearing,
        PayrollExpenses,
        PayrollTaxPayable,
        PenaltiesSettlements,
        PersonalExpense,
        PersonalIncome,
        PreferredStock,
        PrepaidExpenses,
        PrepaidExpensesPayable,
        PromotionalMeals,
        PropertyTaxHomeOffice,
        RentAndLeaseHomeOffice,
        RentOrLeaseOfBuildings,
        RentsHeldInTrust,
        RentsInTrustLiability,
        RepairsAndMaintainceHomeOffice,
        RepairMaintenance,
        Retainage,
        RetainedEarnings,
        SalesOfProductIncome,
        SalesTaxPayable,
        Savings,
        SecurityDeposits,
        ServiceFeeIncome,
        ShareholderNotesPayable,
        ShippingFreightDelivery,
        ShippingFreightDeliveryCos,
        StateLocalIncomeTaxPayable,
        SuppliesMaterials,
        SuppliesMaterialsCogs,
        TaxesPaid,
        TaxExemptInterest,
        Travel,
        TravelMeals,
        TreasuryStock,
        TrustAccounts,
        TrustAccountsLiabilities,
        UnappliedCashBillPaymentExpense,
        UnappliedCashPaymentIncome,
        UndepositedFunds,
        Utilities,
        UtilitiesHomeOffice,
        Vehicle,
        VehicleInsurance,
        VehicleLease,
        VehicleLoan,
        VehicleLoanInterest,
        VehicleRegistration,
        VehicleRepairs,
        Vehicles,
        WashAndRoadServices,
        WithholdingTaxSales,
        WithholdingTaxPurchases,
        WithholdingAssetAmount,
        WithholdingLiabilityAmount,
        WithholdingTaxSuspense,
        ProvisionsCurrentAssets,
        OtherConsumables,
        ExpenditureAuthorisationsAndLettersOfCredit,
        InternalTransfers,
        ProvisionsFixedAssets,
        AssetsInCourseOfConstruction,
        ParticipatingInterests,
        CumulativeDepreciationOnIntangibleAssets,
        ProvisionsNonCurrentAssets,
        OutstandingDuesMicroSmallEnterprise,
        OutstandingDuesOtherThanMicroSmallEnterprise,
        GlobalTaxRefund,
        GlobalTaxDeferred,
        ProvisionsCurrentLiabilities,
        StaffAndRelatedLiabilityAccounts,
        SocialSecurityAgencies,
        SundryDebtorsAndCreditors,
        ProvisionsNonCurrentLiabilities,
        DebtsRelatedToParticipatingInterests,
        StaffAndRelatedLongTermLiabilityAccounts,
        GovernmentAndOtherPublicAuthorities,
        GroupAndAssociates,
        InvestmentGrants,
        CashReceiptIncome,
        OwnWorkCapitalized,
        OperatingGrants,
        OtherCurrentOperatingIncome,
        CostOfSales,
        CashExpenditureExpense,
        ExternalServices,
        OtherExternalServices,
        PurchasesRebates,
        OtherRentalCosts,
        ProjectStudiesSurveysAssessments,
        Sundry,
        StaffCosts,
        OtherCurrentOperatingCharges,
        ExtraordinaryCharges,
        AppropriationsToDepreciation,
        AccrualsAndDeferredIncome,
        CurrentTaxLiability,
        DeferredTax,
        DistributionCosts,
        Investments,
        LongTermBorrowings,
        OtherIntangibleAssets,
        PrepaymentsAndAccruedIncome,
        ShortTermBorrowings,
        ProvisionForLiabilities,
        CalledUpShareCapital,
        CalledUpShareCapitalNotPaid,
        LandAsset,
        AvailableForSaleFinancialAssets,
        ProvisionForWarrantyObligations,
        CurrentPortionEmployeeBenefitsObligations,
        LongTermEmployeeBenefitObligations,
        ObligationsUnderFinanceLeases,
        BankLoans,
        InterestPayables,
        GainLossOnSaleOfInvestments,
        GainLossOnSaleOfFixedAssets,
        ShareCapital,
        CurrentPortionOfObligationsUnderFinanceLeases,
        AssetsHeldForSale,
        AccruedLiabilities,
        AccruedLongLermLiabilities,
        AccruedVacationPayable,
        CashAndCashEquivalents,
        CommissionsAndFees,
        AmortizationExpense,
        LossOnDiscontinuedOperationsNetOfTax,
        ManagementCompensation,
        OtherSellingExpenses,
        LiabilitiesRelatedToAssetsHeldForSale,
        LongTermDebit,
        EquityInEarningsOfSubsiduaries,
        OtherOperatingIncome,
        RevenueGeneral,
        DividendDisbursed,
        FreightAndDeliveryCos,
        ShippingAndDeliveryExpense,
        TravelExpensesGeneralAndAdminExpenses,
        TravelExpensesSellingExpense,
        UnrealisedLossOnSecuritiesNetOfTax,
        SalesRetail,
        SalesWholesale,
        AccumulatedOtherComprehensiveIncome,
        AssetsAvailableForSale,
        LossOnDisposalOfAssets,
        NonCurrentAssets,
        IncomeTaxExpense,
        LongTermInvestments,
        DividendsPayable,
        TradeAndOtherReceivables,
        TradeAndOtherPayables,
        CurrentLiabilities,
        SavingsByTaxScheme,
        BorrowingCost,
        Depletion,
        ExceptionalItems,
        PriorPeriodItems,
        ExtraordinaryItems,
        MatCredit,
        OtherFreeReserves,
        CapitalReserves,
        Funds,
        MoneyReceivedAgainstShareWarrants,
        ShareApplicationMoneyPendingAllotment,
        DeferredTaxLiabilities,
        OtherLongTermProvisions,
        CapitalWip,
        IntangibleAssetsUnderDevelopment,
        OtherLongTermInvestments,
        LongTermLoansAndAdvancesToRelatedParties,
        OtherLongTermLoansAndAdvances,
        ShortTermInvestmentsInRelatedParties,
        OtherEarmarkedBankAccounts,
        ShortTermLoansAndAdvancesToRelatedParties,
        DeferredTaxExpense,
        IncomeTaxOtherExpense,
        DutiesAndTaxes,
        BalWithGovtAuthorities,
        TaxRoundoffGainOrLoss,
    }
    public enum APCreditCardOperationEnum
    {
        Unspecified = 0,
        Charge,
        Credit,
    }
    public enum DayOfWeekEnum
    {
        Unspecified = 0,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }
    public enum EstimateStatusEnum
    {
        Unspecified = 0,
        Active,
        NotActive,
    }
    public enum PaymentMethodEnum
    {
        Unspecified = 0,
        AmEx,
        Cash,
        Check,
        DebitCard,
        Discover,
        ECheck,
        GiftCard,
        MasterCard,
        Other,
        OtherCreditCard,
        Visa,
    }
    public enum PaymentStatusEnum
    {
        Unspecified = 0,
        Draft,
        Overdue,
        Pending,
        Payable,
        Paid,
        Trash,
        UnPaid,
    }
    public enum PaySalesTaxEnum
    {
        Unspecified = 0,
        Annually,
        Monthly,
        Quarterly,
    }
    public enum PerItemAdjustEnum
    {
        Unspecified = 0,
        Cost,
        CurrentCustomPrice,
        StandardPrice,
    }
    public enum PriceLevelTypeEnum
    {
        Unspecified = 0,
        FixedPercentage,
        PerItem,
    }
    public enum QboEstimateStatusEnum
    {
        Unspecified = 0,
        Accepted,
        Closed,
        Pending,
        Rejected,
    }
    public enum PurchaseOrderStatusEnum
    {
        Unspecified = 0,
        Open,
        Closed,
    }
    public enum ReimbursableTypeEnum
    {
        Unspecified = 0,
        Billable,
        BillableHasBeenBilled,
        NotBillable,
    }
    public enum RoundingMethodEnum
    {
        Unspecified = 0,
        Down,
        Nearest,
        None,
        Up,
    }
    public enum SalesRepTypeEnum
    {
        Unspecified = 0,
        Employee,
        Other,
        Vendor,
    }
    public enum SalesTermTypeEnum
    {
        Unspecified = 0,
        DateDriven,
        Standard,
    }
    public enum SpecialItemTypeEnum
    {
        Unspecified = 0,
        FinanceCharge,
        ReimbursableExpenseGroup,
        ReimbursableExpenseSubtotal,
    }
    public enum SymbolPositionEnum
    {
        Unspecified = 0,
        Leading,
        Trailing,
    }
    public enum TaxTypeApplicablityEnum
    {
        Unspecified = 0,
        TaxOnAmount,
        TaxOnAmountPlusTax,
        TaxOnTax,
    }
    public enum TemplateTypeEnum
    {
        Unspecified = 0,
        BuildAssembly,
        CreditMemo,
        Estimate,
        Invoice,
        PurchaseOrder,
        SalesOrder,
        SalesReceipt,
        StatementCharge,
    }
    public enum TimeActivityTypeEnum
    {
        Unspecified = 0,
        Employee,
        Other,
        Vendor,
    }
    public enum TxnTypeEnum
    {
        Unspecified = 0,
        APCreditCard,
        ARRefundCreditCard,
        Bill,
        BillPaymentCheck,
        BuildAssembly,
        CarryOver,
        CashPurchase,
        Charge,
        Check,
        CreditCardPayment,
        CreditMemo,
        Deposit,
        EFPLiabilityCheck,
        EFTBillPayment,
        EFTRefund,
        Estimate,
        InventoryAdjustment,
        InventoryTransfer,
        Invoice,
        ItemReceipt,
        JournalEntry,
        LiabilityAdjustment,
        Paycheck,
        PayrollLiabilityCheck,
        PurchaseOrder,
        PriorPayment,
        ReceivePayment,
        RefundCheck,
        ReimburseCharge,
        SalesOrder,
        SalesReceipt,
        SalesTaxPaymentCheck,
        Transfer,
        TimeActivity,
        VendorCredit,
        YTDAdjustment,
    }
    public enum UOMBaseTypeEnum
    {
        Unspecified = 0,
        Area,
        Count,
        Length,
        Other,
        Time,
        Volume,
        Weight,
    }
    public enum PaymentTypeEnum
    {
        Unspecified = 0,
        Cash,
        Check,
        CreditCard,
        Expense,
        Other,
    }
    public enum BillPaymentTypeEnum
    {
        Unspecified = 0,
        Check,
        CreditCard,
    }
    public enum PrintStatusEnum
    {
        Unspecified = 0,
        NotSet,
        NeedToPrint,
        PrintComplete,
    }
    public enum EmailStatusEnum
    {
        Unspecified = 0,
        NotSet,
        NeedToSend,
        EmailSent,
    }
    public enum ETransactionStatusEnum
    {
        Unspecified = 0,
        Sent,
        Viewed,
        Paid,
        [EnumMember(Value = "Delivery Error")]
        DeliveryError,
        Updated,
        Error,
        Accepted,
        Rejected,
        [EnumMember(Value = "Sent With ICN Error")]
        SentWithICNError,
        Delivered,
        Disputed,
    }
    public enum ETransactionEnabledStatusEnum
    {
        Unspecified = 0,
        Enabled,
        NotApplicable,
    }
    public enum GlobalTaxCalculationEnum
    {
        Unspecified = 0,
        TaxInclusive,
        TaxExcluded,
        NotApplicable,
    }
    public enum TxnSourceEnum
    {
        Unspecified = 0,
        QBMobile,
        GoPayment,
        EInvoice,
        Square,
    }
    public enum BudgetTypeEnum
    {
        Unspecified = 0,
        ProfitAndLoss,
        BalanceSheet,
    }
    public enum BudgetEntryTypeEnum
    {
        Unspecified = 0,
        Yearly,
        Quarterly,
        Monthly,
    }
    public enum ItemCategoryTypeEnum
    {
        Unspecified = 0,
        Product,
        Service,
    }
    public enum TransactionLocationTypeEnum
    {
        Unspecified = 0,
        WithinFrance,
        FranceOverseas,
        OutsideFranceWithEU,
        OutsideEU,
    }
    public enum JournalCodeTypeEnum
    {
        Unspecified = 0,
        Expenses,
        Sales,
        Bank,
        Nouveaux,
        Wages,
        Cash,
        Others,
    }
    public enum DiscountTypeEnum
    {
        Unspecified = 0,
        Rate,
        Amount,
    }
    public enum ServiceTypeEnum
    {
        Unspecified = 0,
        ADVT,
        AIRPORTSERVICES,
        AIRTRANSPORT,
        AIRTRVLAGNT,
        ARCHITECT,
        ASSTMGMT,
        ATMMAINTENANCE,
        AUCTIONSERV,
        AUTHSERST,
        BANKANDFIN,
        BEAUTYPARLOR,
        BROADCAST,
        BUSINESSAUX,
        BUSINESSEXHIBITION,
        BUSINESSSUPPORTSERV,
        CA,
        CABLEOPTR,
        CARGOHAND,
        CLEANINGSERV,
        CLEARANDFORW,
        CLUBSANDASSSERVICE,
        COMMCOACHORTRAINING,
        CONSENG,
        CONSTRCOMMERCIALCOMPLEX,
        CONTAINERRAILTRANS,
        CONVSERV,
        COSTACC,
        COURIER,
        CREDITCARD,
        CREDITRATAGNCY,
        CRUISESHIPTOUR,
        CS,
        CUSHOUSEAG,
        DESIGNSERV,
        DEVELOPSUPPLYCONTENT,
        DREDGING,
        DRYCLEANING,
        ERECTIONCOMMORINSTALL,
        EVENTMGMT,
        FASHIONDES,
        FOREXBROKING,
        FORWARDCONTRACT,
        FRANCHISESERV,
        GENERALINSURANCE,
        GOODSTRANSPORT,
        HEALTHCLUBANDFITNESS,
        INFORMATIONSERV,
        INSURAUX,
        INTDEC,
        INTELLECTUALPROPERTY,
        INTERNATIONALAIRTRAVEL,
        INTERNETCAFE,
        INTERNETTELEPHONY,
        LIFEINS,
        MAILLISTCOMPILE,
        MANDAPKEEPER,
        MANPWRRECRUIT,
        MGMTCONSUL,
        MGMTMAINTREPAIR,
        MININGOIL,
        MKTRESAGNCY,
        ONLINEINFORMRETRIEVAL,
        OPINIONPOLL,
        OUTDOORCATERING,
        PACKAGINGSERV,
        PANDALSHAMIANA,
        PHOTOGRAPHY,
        PORT,
        PORTSER,
        PROCESSCLEARHOUSE,
        PUBLICRELATIONMGMT,
        RAILTRAVELAGNT,
        REALESTAGT,
        RECOVERYAGENTS,
        REGISTRARSERV,
        RENTACAB,
        RENTINGIMMOVABLEPROP,
        RESIDENTIALCOMPLEXCONST,
        SALEOFSPACEFORADVT,
        SCANDTECHCONSUL,
        SECAG,
        SERVICESPROVIDEDFORTRANSACTION,
        SHARETRANSFERSERV,
        SHIPMGMT,
        SITEPREP,
        SOUNDRECORD,
        SPONSORSHIP,
        STAG,
        STOCKBROKING,
        STOCKEXCHGSERV,
        STORANDWAREHOUSING,
        SUPPLYTANGIBLEGOODS,
        SURVEYANDMAPMAKING,
        SURVEYMINERALS,
        TECHINSPECTION,
        TECHTESTING,
        TELECOMMUNICATIONSERV,
        TELEVISIONANDRADIO,
        TOUROP,
        TRANSPORTPIPELINE,
        TRAVELAGENT,
        ULIPMANAGEMENT,
        UNDERWRITER,
        VIDEOTAPEPROD,
        WORKSCONTRACT,
    }
    public enum QboEntityTypeEnum
    {
        Unspecified = 0,
        CUSTOMER,
        VENDOR,
        EMPLOYEE,
        CREDIT_CARD,
        CHECK,
        INVOICE,
        RECEIVED_PAYMENT,
        GENERAL_JOURNAL,
        BILL,
        CREDIT_CARD_CREDIT,
        BILL_CREDIT,
        CHARGE_CREDIT,
        BILL_CHECK,
        BILL_CREDIT_CARD,
        CHARGE,
        TRANSFER,
        RECEIVED_MONEY,
        STATEMENT,
        REIMB_CHARGE,
        CASH_PURCHASE,
        CASH_SALE,
        CREDIT_MEMO,
        CREDIT_REFUND,
        ESTIMATE,
        INVENTORY_QUANTITY_ADJUSTMENT,
        PURCHASE_ORDER,
        PAYROLL_CHECK,
        TAX_PAYMENT,
        PAYROLL_ADJUSTMENT_V2,
        PAYROLL_REFUND,
        GLOBAL_TAX_PAYMENT,
        GLOBAL_TAX_ADJUSTMENT,
        JOB_INVOICE,
        ITEM,
        GENERIC_EXPENSE,
        TIME_ACTIVITY,
        DEPARTMENT,
        USERS,
        KLASS,
        PAYMENT_METHOD,
        MEMORIZED_TRANSACTION,
        TERM,
        BUDGET,
        TAX_CODE,
        TAX_CODE_RATE,
        TAX_AGENCY,
        ATTACHABLE,
        ACCOUNT,
        PREFERENCES,
        JOURNAL_CODE,
        DISCOUNT_RATE,
        BANKING_TRANSACTIONS,
        BUSINESS_TERMS,
        LIABILITY_CHECK,
        LIABILITY_CREDIT_CARD,
        LIABILITY_REFUND,
        PRIOR_LIABILITY_PAYMENTS,
        LIABILITY_EPAY,
        LIABILITY_MMAP,
        TAX_CREDIT_UTILISE,
        TAX_CREDIT_DEFER,
        TAX_CREDIT_REVERSE,
        TAX_CREDIT_REFUND,
        GROSS_ADJUSTMENT,
        REVERSE_CHARGE,
        DD_CHECK,
        PAYCHECK,
        PAYROLL_ADJUSTMENT,
        PAYROLL_YTD,
        SDK_USERS,
        PAYROLL_ITEMS,
        PAY_GROUPS,
        PAID_TIME_OFF_ENTRIES,
        TAX_JURISDICTIONS,
        MEMORIZED_REPORTS,
        OLB_FINANCIAL_INSTITUTIONS,
        DIRECT_DEPOSIT_BANK_INFO,
        REMINDERS,
        PAYROLL_FORMS,
        EPAY_BANK_ACCOUNT_INFO,
        EPAY_AGENCY_CREDENTIALS,
        EFILE_ENROLLMENT,
        TAXRETURNLINES,
        NOTES,
        PRINT_PREF,
        MANAGEMENT_REPORT,
        OLB_RULES,
        DESKTOPIMPORT_SEED_QOH,
    }
    public enum DesktopEntityTypeEnum
    {
        Unspecified = 0,
        ANY,
        CREDIT_CARD,
        DEPOSIT,
        CHECK,
        INVOICE,
        CASHSALE,
        CREDIT_MEMO,
        APP_PAY,
        GENERAL_JOURNAL,
        BILL,
        GENERIC,
        CREDIT_CARD_REFUND,
        BILL_REFUND,
        AR_CREDIT_CARD_REFUND,
        BILL_CHECK,
        BILL_CREDIT_CARD,
        SALES_TAX_PAYMENT,
        PURCHASE_ORDER,
        INVENTORY_ADJUSTMENT,
        INVENTORY_RECEIPT,
        PAYCHECK,
        LIABILITY_CHECK,
        BEGIN_BALANCE_CHECK,
        LIABILITY_ADJUSTMENT,
        ESTIMATE,
        STATEMENT_CHARGE,
        TRANSFER,
        SALESORDER,
        QBRSLIABCHECK,
        BUILDASSEMBLY,
        EFPLIABCHECK,
        PRIOR_PMT,
        LIAB_REFUND_CHECK,
        ITEM_SERVICE,
        ITEM_INVENTORY,
        ITEM_ASSEMBLY,
        ITEM_PART,
        ITEM_FIXEDASSET,
        ITEM_CHARGES,
        ITEM_SUBTOTAL,
        ITEM_GROUP,
        ITEM_DISCOUNT,
        ITEM_PAYMENT,
        ITEM_TAXCOMP,
        ITEM_TAXGROUP,
        ITEM_GROUPEND,
        ITEM_PURCHASE,
        ITEM_PO,
        ITEM_INVOICE,
        ITEM_ALLITEMS,
        ITEM_NOTAXES,
        ITEM_SERVICES_AND_CHARGES,
        ITEM_REAL_GROUP_END,
        ITEM_MAX,
        CUSTOMER,
        VENDOR,
        EMPLOYEE,
        OTHERNAME,
        NULLLINKTYPE,
        UNUSED1,
        REFUNDCHECKTOCRMEMO,
        INVOICETOCRMEMO,
        INVOICETOPAYMENT,
        INVOICETODISCOUNT,
        BILLTOCHECK,
        BILLTOCCARD,
        BILLTOCREDIT,
        DEPOSITTOPAYMENT,
        REFUNDCHECKTOPAYMENT,
        INVOICETOPMTLINE,
        INVOICETOCREDITLINE,
        BILLTOCREDITLINE,
        CREDLINETODISCLINE,
        PURCHASEORDERTORECEIPT,
        BILLTODISCOUNT,
        INVOICETODISCOUNTLINE,
        INVOICETOESTIMATEQTY,
        INVOICETOESTIMATEAMT,
        INVOICETOSALESORDERQTY,
        INVOICETOSALESORDERAMT,
        JOURNALENTRYTOCRMEMO,
        AR_CCREFUND_TO_CREDITMEMO,
        AR_CCREFUND_TO_PAYMENT,
        AR_CCREFUND_TO_JOURNAL,
        GIRO_TO_CHECK,
        ITEM,
        DEPARTMENT,
        USERS,
        KLASS,
        PAYMENT_METHOD,
        TERM,
        BUDGET,
        TAX_CODE,
        TAX_CODE_RATE,
        TAX_AGENCY,
        ATTACHABLE,
        ACCOUNT,
        PREFERENCES,
    }
    public enum TaxReturnStatusEnum
    {
        Unspecified = 0,
        FILED,
        FILING_FAILED,
        FILING_FAILED_WRONG_AGENCY_CREDENTIALS,
        AGENCY_PAYMENT_INITIATED,
        AGENCY_PAYMENT_COMPLETED,
    }
    public enum AgencyPaymentMethodEnum
    {
        Unspecified = 0,
        ACH_CREDIT,
        ACH_DEBIT,
        CHECK,
        WIRE,
        OTHER,
    }
    public enum TaxReviewStatusEnum
    {
        Unspecified = 0,
        NON_AST_TAX,
        AST_TAX_OVERRIDE,
    }
    public enum ConvenienceFeeTypeEnum
    {
        Unspecified = 0,
        MANUAL,
        AUTO,
        PAID,
        DISABLED,
    }
    public enum SpecialTaxTypeEnum
    {
        Unspecified = 0,
        NONE,
        ZERO_RATE,
        FOREIGN_TAX,
        REVERSE_CHARGE,
        ADJUSTMENT_RATE,
    }
    public enum GTMConfigTypeEnum
    {
        Unspecified = 0,
        SYSTEM_GENERATED,
        USER_DEFINED,
        SCRA_DEFINED,
        HIDDEN_AGENCY,
    }
    public enum AttachableCategoryEnum
    {
        Unspecified = 0,
        Image,
        Signature,
        [EnumMember(Value = "Contact Photo")]
        ContactPhoto,
        Receipt,
        Document,
        Sound,
        Other,
    }
    public enum OLBTxnStatusEnum
    {
        Unspecified = 0,
        Pending,
        Approved,
        Deleted,
    }
    public enum ContactTypeEnum
    {
        Unspecified = 0,
        TelephoneNumber,
        EmailAddress,
        WebSiteAddress,
        GenericContactType,
    }
    public enum DeliveryTypeEnum
    {
        Unspecified = 0,
        Email,
        Tradeshift,
    }
    public enum DeliveryErrorTypeEnum
    {
        Unspecified = 0,
        [EnumMember(Value = "Missing Info")]
        MissingInfo,
        Undeliverable,
        [EnumMember(Value = "Delivery Server Down")]
        DeliveryServerDown,
        [EnumMember(Value = "Bounced Email")]
        BouncedEmail,
    }
    public enum EmailAddressTypeEnum
    {
        Unspecified = 0,
        Primary,
        CC,
    }
    public enum PhysicalAddressTypeEnum
    {
        Unspecified = 0,
        Billing,
        Shipping,
    }
    public enum TelephoneNumberTypeEnum
    {
        Unspecified = 0,
        Business,
        Fax,
        Home,
        Mobile,
        Pager,
        Primary,
        Secondary,
        Other,
    }
    public enum TelephoneDeviceTypeEnum
    {
        Unspecified = 0,
        LandLine,
        Mobile,
        Fax,
        Pager,
    }
    public enum gender
    {
        Unspecified = 0,
        Male,
        Female,
    }
    public enum CCSecurityCodeMatchEnum
    {
        Unspecified = 0,
        Fail,
        NotAvailable,
        Pass,
    }
    public enum CCAVSMatchEnum
    {
        Unspecified = 0,
        Fail,
        NotAvailable,
        Pass,
    }
    public enum CCPaymentStatusEnum
    {
        Unspecified = 0,
        Completed,
        Voided,
        Unknown,
    }
    public enum CCTxnModeEnum
    {
        Unspecified = 0,
        CardNotPresent,
        CardPresent,
    }
    public enum CCTxnTypeEnum
    {
        Unspecified = 0,
        Authorization,
        Capture,
        Charge,
        Refund,
        VoiceAuthorization,
    }
    public enum CreditCardTypeEnum
    {
        Unspecified = 0,
        AmEx,
        DebitCard,
        Discover,
        GiftCard,
        MasterCard,
        OtherCreditCard,
        Visa,
    }
    public enum CustomFieldTypeEnum
    {
        Unspecified = 0,
        StringType,
        BooleanType,
        NumberType,
        DateType,
    }
    public enum EntityStatusEnum
    {
        Unspecified = 0,
        Deleted,
        Voided,
        Draft,
        Pending,
        InTransit,
        Synchronized,
        SyncError,
    }
    public enum currencyCode
    {
        Unspecified = 0,
        AED,
        AFA,
        ALL,
        ANG,
        AOA,
        AOK,
        ARP,
        ARS,
        AMD,
        ATS,
        AUD,
        AWF,
        AWG,
        AZM,
        BAM,
        BBD,
        BDT,
        BEF,
        BGL,
        BHD,
        BIF,
        BMD,
        BND,
        BOB,
        BRC,
        BRL,
        BSD,
        BTN,
        BUK,
        BWP,
        BYR,
        BYB,
        BZD,
        CAD,
        CDF,
        CHF,
        CLP,
        CNY,
        COP,
        CRC,
        CZK,
        CUP,
        CVE,
        DDM,
        DEM,
        DJF,
        DKK,
        DOP,
        DZD,
        ECS,
        EEK,
        EGP,
        ERN,
        ESP,
        ETB,
        EUR,
        FIM,
        FJD,
        FKP,
        FRF,
        GBP,
        GEL,
        GHC,
        GIP,
        GMD,
        GNF,
        GRD,
        GTQ,
        GWP,
        GYD,
        HKD,
        HNL,
        HRK,
        HTG,
        HUF,
        IDR,
        IEP,
        ILS,
        INR,
        IQD,
        IRR,
        ISK,
        ITL,
        JMD,
        JOD,
        KES,
        KGS,
        KHR,
        KMF,
        KPW,
        KRW,
        KWD,
        KYD,
        KZT,
        LAK,
        LBP,
        LKR,
        LRD,
        LSL,
        LTL,
        LUF,
        LVL,
        LYD,
        MAD,
        MDL,
        MGF,
        MKD,
        MMK,
        MNT,
        MOP,
        MRO,
        MUR,
        MVR,
        MWK,
        MXN,
        MXP,
        MYR,
        MZM,
        NAD,
        NGN,
        NIC,
        NIO,
        NLG,
        NOK,
        NPR,
        NZD,
        OMR,
        PAB,
        PEN,
        PES,
        PGK,
        PHP,
        PKR,
        PLN,
        PLZ,
        PTE,
        PYG,
        QAR,
        ROL,
        RUR,
        RWF,
        SAR,
        SBD,
        SCR,
        SDD,
        SDP,
        SEK,
        SGD,
        SHP,
        SIT,
        SKK,
        SLL,
        SM,
        SOS,
        SRG,
        STD,
        SUR,
        SVC,
        SYP,
        SZL,
        THB,
        TMM,
        TND,
        TOP,
        TRL,
        TTD,
        TWD,
        TZS,
        UAH,
        UGS,
        UGX,
        USD,
        UYP,
        UYU,
        UZS,
        VND,
        VUV,
        VAL,
        WST,
        XAF,
        XCD,
        XOF,
        XPF,
        YER,
        YUD,
        ZAR,
        ZMK,
        ZRZ,
        ZWD,
    }
    public enum idDomainEnum
    {
        Unspecified = 0,
        BM,
        NG,
        PMT,
        QB,
        QBO,
        QBSDK,
    }
    public enum objectNameEnumType
    {
        Unspecified = 0,
        Account,
        All,
        Attachable,
        Bill,
        BillPayment,
        BOMComponent,
        ChargeCredit,
        Class,
        Company,
        CompanyInfo,
        CreditCardPaymentTxn,
        CreditMemo,
        Customer,
        CustomerType,
        Discount,
        Department,
        Deposit,
        Employee,
        Estimate,
        FixedAsset,
        InventoryAdjustment,
        InventorySite,
        Invoice,
        Item,
        ItemReceipt,
        JournalEntry,
        ListObjectType,
        Names,
        OtherName,
        Payment,
        PaymentMethod,
        Preferences,
        PriceLevel,
        Purchase,
        PurchaseOrder,
        RecurringTransaction,
        RefundReceipt,
        ReimburseCharge,
        Report,
        SalesOrder,
        SalesReceipt,
        SalesRep,
        ShipMethod,
        StatementCharge,
        Tag,
        TaxCode,
        TaxClassification,
        TaxPayment,
        TaxRate,
        TaxReturn,
        Term,
        TimeActivity,
        Transfer,
        Transaction,
        TxnLocation,
        UOM,
        Vendor,
        VendorCredit,
        CustomFieldDefinition,
    }
    public enum ReportBasisEnum
    {
        Unspecified = 0,
        Accrual,
        Cash,
    }
    public enum EmployeeTypeEnum
    {
        Unspecified = 0,
        Officer,
        Owner,
        Regular,
        Statutory,
    }
    public enum SubcontractorTypeEnum
    {
        Unspecified = 0,
        Individual,
        Company,
        Partnership,
        Trust,
    }
    public enum CISRateEnum
    {
        Unspecified = 0,
        [EnumMember(Value = "CIS gross rate (0%)")]
        CISgrossrate0,
        [EnumMember(Value = "CIS standard rate (20%)")]
        CISstandardrate20,
        [EnumMember(Value = "CIS higher rate (30%)")]
        CIShigherrate30,
    }
    public enum JobStatusEnum
    {
        Unspecified = 0,
        Awarded,
        Closed,
        InProgress,
        None,
        NotAwarded,
        Pending,
    }
    public enum TimeEntryUsedForPaychecksEnum
    {
        Unspecified = 0,
        NotSet,
        DoNotUseTimeEntry,
        UseTimeEntry,
    }
    public enum TaxReportBasisTypeEnum
    {
        Unspecified = 0,
        Cash,
        Accrual,
    }
    public enum FifoCalculationStatus
    {
        Unspecified = 0,
        None,
        InProgress,
        Completed,
        Error,
    }
    public enum FaultTypeEnum
    {
        Unspecified = 0,
        AuthenticationFault,
        AuthorizatonFault,
        ValidationFault,
        SystemFault,
    }
    public enum OperationEnum
    {
        Unspecified = 0,
        create,
        update,
        revert,
        delete,
        [EnumMember(Value = "void")]
        @void,
        send,
        merge,
    }
    public enum SyncType
    {
        Unspecified = 0,
        Upload,
        Writeback,
    }
    public enum SyncErrorType
    {
        Unspecified = 0,
        OutOfSync,
        BusinessLogic,
        SystemError,
    }
    public enum DateMacro
    {
        Unspecified = 0,
        All,
        Today,
        [EnumMember(Value = "This Week")]
        ThisWeek,
        [EnumMember(Value = "This Week-to-date")]
        ThisWeektodate,
        [EnumMember(Value = "This Month")]
        ThisMonth,
        [EnumMember(Value = "This Month-to-date")]
        ThisMonthtodate,
        [EnumMember(Value = "This Fiscal Quarter")]
        ThisFiscalQuarter,
        [EnumMember(Value = "This Fiscal Quarter-to-date")]
        ThisFiscalQuartertodate,
        [EnumMember(Value = "This Fiscal Year")]
        ThisFiscalYear,
        [EnumMember(Value = "This Fiscal Year-to-date")]
        ThisFiscalYeartodate,
        [EnumMember(Value = "This Calendar Quarter")]
        ThisCalendarQuarter,
        [EnumMember(Value = "This Calendar Quarter-to-date")]
        ThisCalendarQuartertodate,
        [EnumMember(Value = "This Calendar Year")]
        ThisCalendarYear,
        [EnumMember(Value = "This Calendar Year-to-date")]
        ThisCalendarYeartodate,
        Yesterday,
        [EnumMember(Value = "Last Week")]
        LastWeek,
        [EnumMember(Value = "Last Week-to-date")]
        LastWeektodate,
        [EnumMember(Value = "Last Month")]
        LastMonth,
        [EnumMember(Value = "Last Month-to-date")]
        LastMonthtodate,
        [EnumMember(Value = "Last Fiscal Quarter")]
        LastFiscalQuarter,
        [EnumMember(Value = "Last Fiscal Quarter-to-date")]
        LastFiscalQuartertodate,
        [EnumMember(Value = "Last Fiscal Year")]
        LastFiscalYear,
        [EnumMember(Value = "Last Fiscal Year-to-date")]
        LastFiscalYeartodate,
        [EnumMember(Value = "Last Calendar Quarter")]
        LastCalendarQuarter,
        [EnumMember(Value = "Last Calendar Quarter-to-date")]
        LastCalendarQuartertodate,
        [EnumMember(Value = "Last Calendar Year")]
        LastCalendarYear,
        [EnumMember(Value = "Last Calendar Year-to-date")]
        LastCalendarYeartodate,
        [EnumMember(Value = "Next Week")]
        NextWeek,
        [EnumMember(Value = "Next 4 Weeks")]
        Next4Weeks,
        [EnumMember(Value = "Next Month")]
        NextMonth,
        [EnumMember(Value = "Next Fiscal Quarter")]
        NextFiscalQuarter,
        [EnumMember(Value = "Next Fiscal Year")]
        NextFiscalYear,
        [EnumMember(Value = "Next Calendar Quarter")]
        NextCalendarQuarter,
        [EnumMember(Value = "Next Calendar Year")]
        NextCalendarYear,
    }
    public enum SummarizeColumnsByEnum
    {
        Unspecified = 0,
        Total,
        Year,
        Quarter,
        FiscalYear,
        FiscalQuarter,
        Month,
        Week,
        Days,
        Customers,
        Vendors,
        Employees,
        Departments,
        Classes,
        ProductsAndServices,
    }
    public enum ColumnTypeEnum
    {
        Unspecified = 0,
        Account,
        Money,
        Rate,
        Customer,
        Vendor,
        Employee,
        ProductsAndService,
        Department,
        Class,
        String,
    }
    public enum RowTypeEnum
    {
        Unspecified = 0,
        Section,
        Data,
    }
    public enum TaxRateApplicableOnEnum
    {
        Unspecified = 0,
        Sales,
        Purchase,
        Adjustment,
        Other,
    }
    public class LinkedTxn
    {
        public string? TxnId { get; set; }
        public string? TxnType { get; set; }
        public string? TxnLineId { get; set; }
    }
    public class TxnApprovalInfo
    {
        public string? ApprovalStatus { get; set; }
        public string? ApprovalStatusDetail { get; set; }
        public string? LastChangedByUser { get; set; }
        public DateTimeOffset? LastChangedDate { get; set; }
    }
    public class QbdtEntityIdMapping : IntuitEntity
    {
        public string QboEntityId { get; set; } = default!;
        public string QbdtExportableId { get; set; } = default!;
        public string QboEntityType { get; set; } = default!;
        public string QbdtEntityType { get; set; } = default!;
    }
    public class Company : IntuitEntity
    {
        public string? CompanyName { get; set; }
        public string? LegalName { get; set; }
        public PhysicalAddress? CompanyAddr { get; set; }
        public PhysicalAddress? CustomerCommunicationAddr { get; set; }
        public PhysicalAddress? LegalAddr { get; set; }
        public EmailAddress? CompanyEmailAddr { get; set; }
        public EmailAddress? CustomerCommunicationEmailAddr { get; set; }
        public WebSiteAddress? CompanyURL { get; set; }
        public TelephoneNumber? PrimaryPhone { get; set; }
        public ContactInfo[]? OtherContactInfo { get; set; }
        public string? CompanyFileName { get; set; }
        public string? FlavorStratum { get; set; }
        public bool? SampleFile { get; set; }
        public string? CompanyUserId { get; set; }
        public string? CompanyUserAdminEmail { get; set; }
        public DateTime? CompanyStartDate { get; set; }
        public string? EmployerId { get; set; }
        public MonthEnum? FiscalYearStartMonth { get; set; }
        public MonthEnum? TaxYearStartMonth { get; set; }
        public string? QBVersion { get; set; }
        public string? Country { get; set; }
        public PhysicalAddress? ShipAddr { get; set; }
        public PhysicalAddress[]? OtherAddr { get; set; }
        public TelephoneNumber? Mobile { get; set; }
        public TelephoneNumber? Fax { get; set; }
        public EmailAddress? Email { get; set; }
        public WebSiteAddress? WebSite { get; set; }
        public DateTimeOffset? LastImportedTime { get; set; }
        public string? SupportedLanguages { get; set; }
        public string? DefaultTimeZone { get; set; }
        public bool? MultiByteCharsSupported { get; set; }
        public NameValue[]? NameValue { get; set; }
        public IntuitAnyType? CompanyInfoEx { get; set; }
    }
    public class CompanyInfo : IntuitEntity
    {
        public string? CompanyName { get; set; }
        public string? LegalName { get; set; }
        public PhysicalAddress? CompanyAddr { get; set; }
        public PhysicalAddress? CustomerCommunicationAddr { get; set; }
        public PhysicalAddress? LegalAddr { get; set; }
        public EmailAddress? CompanyEmailAddr { get; set; }
        public EmailAddress? CustomerCommunicationEmailAddr { get; set; }
        public WebSiteAddress? CompanyURL { get; set; }
        public TelephoneNumber? PrimaryPhone { get; set; }
        public ContactInfo[]? OtherContactInfo { get; set; }
        public string? CompanyFileName { get; set; }
        public string? FlavorStratum { get; set; }
        public bool? SampleFile { get; set; }
        public string? CompanyUserId { get; set; }
        public string? CompanyUserAdminEmail { get; set; }
        public DateTime? CompanyStartDate { get; set; }
        public string? EmployerId { get; set; }
        public MonthEnum? FiscalYearStartMonth { get; set; }
        public MonthEnum? TaxYearStartMonth { get; set; }
        public string? QBVersion { get; set; }
        public string? Country { get; set; }
        public PhysicalAddress? ShipAddr { get; set; }
        public PhysicalAddress[]? OtherAddr { get; set; }
        public TelephoneNumber? Mobile { get; set; }
        public TelephoneNumber? Fax { get; set; }
        public EmailAddress? Email { get; set; }
        public WebSiteAddress? WebAddr { get; set; }
        public DateTimeOffset? LastImportedTime { get; set; }
        public DateTimeOffset? LastSyncTime { get; set; }
        public string? SupportedLanguages { get; set; }
        public string? DefaultTimeZone { get; set; }
        public bool? MultiByteCharsSupported { get; set; }
        public NameValue[]? NameValue { get; set; }
        public FifoCalculationStatus? FifoCalculationStatus { get; set; }
        public IntuitAnyType? CompanyInfoEx { get; set; }
    }
    public class Transaction : IntuitEntity
    {
        public string? DocNumber { get; set; }
        public DateTime? TxnDate { get; set; }
        public ReferenceType? DepartmentRef { get; set; }
        public ReferenceType? CurrencyRef { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string? PrivateNote { get; set; }
        public string? TxnStatus { get; set; }
        public LinkedTxn[]? LinkedTxn { get; set; }
        public Line[]? Line { get; set; }
        public TxnTaxDetail? TxnTaxDetail { get; set; }
        public string? TxnSource { get; set; }
        public string? TaxFormType { get; set; }
        public string? TaxFormNum { get; set; }
        public string? TransactionLocationType { get; set; }
        public Tag[]? Tag { get; set; }
        public TxnApprovalInfo? TxnApprovalInfo { get; set; }
        public ReferenceType? RecurDataRef { get; set; }
        public RecurringInfo? RecurringInfo { get; set; }
    }
    public class TxnTaxDetail
    {
        public ReferenceType? DefaultTaxCodeRef { get; set; }
        public ReferenceType? TxnTaxCodeRef { get; set; }
        public decimal? TotalTax { get; set; }
        public TaxReviewStatusEnum? TaxReviewStatus { get; set; }
        public Line[]? TaxLine { get; set; }
        public bool? UseAutomatedSalesTax { get; set; }
    }
    public class SalesTransaction : Transaction
    {
        public bool? AutoDocNumber { get; set; }
        public ReferenceType? CustomerRef { get; set; }
        public MemoRef? CustomerMemo { get; set; }
        public PhysicalAddress? BillAddr { get; set; }
        public PhysicalAddress? ShipAddr { get; set; }
        public bool? FreeFormAddress { get; set; }
        public PhysicalAddress? ShipFromAddr { get; set; }
        public ReferenceType? RemitToRef { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public ReferenceType? SalesTermRef { get; set; }
        public DateTime? DueDate { get; set; }
        public ReferenceType? SalesRepRef { get; set; }
        public string? PONumber { get; set; }
        public string? FOB { get; set; }
        public ReferenceType? ShipMethodRef { get; set; }
        public DateTime? ShipDate { get; set; }
        public string? TrackingNum { get; set; }
        public GlobalTaxCalculationEnum? GlobalTaxCalculation { get; set; }
        public decimal? TotalAmt { get; set; }
        public decimal? HomeTotalAmt { get; set; }
        public bool? ApplyTaxAfterDiscount { get; set; }
        public ReferenceType? TemplateRef { get; set; }
        public PrintStatusEnum? PrintStatus { get; set; }
        public EmailStatusEnum? EmailStatus { get; set; }
        public EmailAddress? BillEmail { get; set; }
        public EmailAddress? BillEmailCc { get; set; }
        public EmailAddress? BillEmailBcc { get; set; }
        public ReferenceType? ARAccountRef { get; set; }
        public decimal? Balance { get; set; }
        public decimal? HomeBalance { get; set; }
        public bool? FinanceCharge { get; set; }
        public ReferenceType? PaymentMethodRef { get; set; }
        public string? PaymentRefNum { get; set; }
        public PaymentTypeEnum? PaymentType { get; set; }
        public CheckPayment? CheckPayment { get; set; }
        public CreditCardPayment? CreditCardPayment { get; set; }
        public ReferenceType? DepositToAccountRef { get; set; }
        public TransactionDeliveryInfo? DeliveryInfo { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmt { get; set; }
        public string? GovtTxnRefIdentifier { get; set; }
        public ReferenceType? TaxExemptionRef { get; set; }
    }
    public class Invoice : SalesTransaction
    {
        public decimal? Deposit { get; set; }
        public bool? AllowIPNPayment { get; set; }
        public bool? AllowOnlinePayment { get; set; }
        public bool? AllowOnlineCreditCardPayment { get; set; }
        public bool? AllowOnlineACHPayment { get; set; }
        public ETransactionStatusEnum? EInvoiceStatus { get; set; }
        public DateTimeOffset? ECloudStatusTimeStamp { get; set; }
        public string? invoiceStatus { get; set; }
        public string? callToAction { get; set; }
        public StatusInfo[]? invoiceStatusLog { get; set; }
        public IntuitAnyType? InvoiceEx { get; set; }
        public decimal? LessCIS { get; set; }
        public string? InvoiceLink { get; set; }
        public string? PaymentDetailsMessage { get; set; }
        public ConvenienceFeeDetail? ConvenienceFeeDetail { get; set; }
        public string? InvoiceLinkSecurityCode { get; set; }
        public DateTime? InvoiceLinkExpiryDate { get; set; }
    }
    public class ConvenienceFeeDetail : IntuitEntity
    {
        public ConvenienceFeeTypeEnum? ConvenienceFeeType { get; set; }
        public decimal? ConvenienceFeePercent { get; set; }
    }
    public class SalesReceipt : SalesTransaction
    {
        public IntuitAnyType? SalesReceiptEx { get; set; }
        public decimal? LessCIS { get; set; }
    }
    public class Estimate : SalesTransaction
    {
        public DateTime? ExpirationDate { get; set; }
        public string? AcceptedBy { get; set; }
        public DateTime? AcceptedDate { get; set; }
        public IntuitAnyType? EstimateEx { get; set; }
    }
    public class EmailDeliveryInfo : IntuitEntity
    {
        public EmailAddress? DeliveryAddress { get; set; }
        public EmailAddress? DeliveryAddressCc { get; set; }
        public EmailAddress? DeliveryAddressBcc { get; set; }
        public EmailMessage? EmailMessage { get; set; }
        public bool? AllowOnlinePayment { get; set; }
        public bool? AllowOnlineCreditCardPayment { get; set; }
        public bool? AllowOnlineACHPayment { get; set; }
        public TransactionDeliveryInfo? DeliveryInfo { get; set; }
        public ETransactionStatusEnum? ETransactionStatus { get; set; }
    }
    public class GroupLineDetail
    {
        public ReferenceType GroupItemRef { get; set; } = default!;
        public decimal? Quantity { get; set; }
        public UOMRef? UOMRef { get; set; }
        public DateTime? ServiceDate { get; set; }
        public Line[]? Line { get; set; }
        public IntuitAnyType? GroupLineDetailEx { get; set; }
    }
    public class Line
    {
        public string? Id { get; set; }
        public uint? LineNum { get; set; }
        public string? Description { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Received { get; set; }
        public LinkedTxn[]? LinkedTxn { get; set; }
        public LineDetailTypeEnum? DetailType { get; set; }
        public PaymentLineDetail? PaymentLineDetail { get; set; }
        public DiscountLineDetail? DiscountLineDetail { get; set; }
        public TaxLineDetail? TaxLineDetail { get; set; }
        public SalesItemLineDetail? SalesItemLineDetail { get; set; }
        public DescriptionLineDetail? DescriptionLineDetail { get; set; }
        public ItemBasedExpenseLineDetail? ItemBasedExpenseLineDetail { get; set; }
        public AccountBasedExpenseLineDetail? AccountBasedExpenseLineDetail { get; set; }
        public ReimburseLineDetail? ReimburseLineDetail { get; set; }
        public DepositLineDetail? DepositLineDetail { get; set; }
        public PurchaseOrderItemLineDetail? PurchaseOrderItemLineDetail { get; set; }
        public SalesOrderItemLineDetail? SalesOrderItemLineDetail { get; set; }
        public ItemReceiptLineDetail? ItemReceiptLineDetail { get; set; }
        public JournalEntryLineDetail? JournalEntryLineDetail { get; set; }
        public GroupLineDetail? GroupLineDetail { get; set; }
        public SubTotalLineDetail? SubTotalLineDetail { get; set; }
        public TDSLineDetail? TDSLineDetail { get; set; }
        public CustomField[]? CustomField { get; set; }
        public IntuitAnyType? LineEx { get; set; }
    }
    public class Tag : IntuitEntity
    {
        public string? Name { get; set; }
    }
    public class DiscountOverride
    {
        public ReferenceType? DiscountRef { get; set; }
        public bool? PercentBased { get; set; }
        public decimal? DiscountPercent { get; set; }
        public ReferenceType? DiscountAccountRef { get; set; }
    }
    public class DiscountLineDetail : DiscountOverride
    {
        public DateTime? ServiceDate { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public ReferenceType? TaxCodeRef { get; set; }
        public IntuitAnyType? DiscountLineDetailEx { get; set; }
    }
    public class DescriptionLineDetail
    {
        public DateTime? ServiceDate { get; set; }
        public ReferenceType? TaxCodeRef { get; set; }
        public IntuitAnyType? DescriptionLineDetailEx { get; set; }
    }
    public class TDSLineDetail
    {
        public ReferenceType? TDSAccountRef { get; set; }
        public int? TDSSectionTypeId { get; set; }
        public IntuitAnyType? TDSLineDetailEx { get; set; }
    }
    public class FixedAsset : IntuitEntity
    {
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public AcquiredAsEnum? AcquiredAs { get; set; }
        public string? PurchaseDesc { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? PurchaseCost { get; set; }
        public string? Vendor { get; set; }
        public ReferenceType? AssetAccountRef { get; set; }
        public string? SalesDesc { get; set; }
        public DateTime? SalesDate { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? SalesExpense { get; set; }
        public string? Location { get; set; }
        public string? PONumber { get; set; }
        public string? SerialNumber { get; set; }
        public DateTime? WarrantyExpDate { get; set; }
        public string? Description { get; set; }
        public string? Notes { get; set; }
        public int? AssetNum { get; set; }
        public decimal? CostBasis { get; set; }
        public decimal? Depreciation { get; set; }
        public decimal? BookValue { get; set; }
        public IntuitAnyType? FixedAssetEx { get; set; }
    }
    public abstract class ItemLineDetail
    {
        public ReferenceType? ItemRef { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? RatePercent { get; set; }
        public ReferenceType? PriceLevelRef { get; set; }
        public MarkupInfo? MarkupInfo { get; set; }
        public decimal? Qty { get; set; }
        public UOMRef? UOMRef { get; set; }
        public ReferenceType? ItemAccountRef { get; set; }
        public ReferenceType? InventorySiteRef { get; set; }
        public ReferenceType? TaxCodeRef { get; set; }
        public ReferenceType? TaxClassificationRef { get; set; }
    }
    public class SalesItemLineDetail : ItemLineDetail
    {
        public DateTime? ServiceDate { get; set; }
        public decimal? TaxInclusiveAmt { get; set; }
        public decimal? DiscountRate { get; set; }
        public decimal? DiscountAmt { get; set; }
        public IntuitAnyType? SalesItemLineDetailEx { get; set; }
    }
    public class ItemBasedExpenseLineDetail : ItemLineDetail
    {
        public ReferenceType? CustomerRef { get; set; }
        public BillableStatusEnum? BillableStatus { get; set; }
        public decimal? TaxInclusiveAmt { get; set; }
        public IntuitAnyType? ItemBasedExpenseLineDetailEx { get; set; }
    }
    public class PurchaseOrderItemLineDetail : SalesItemLineDetail
    {
        public string? ManPartNum { get; set; }
        public bool? ManuallyClosed { get; set; }
        public decimal? OpenQty { get; set; }
        public IntuitAnyType? PurchaseOrderItemLineDetailEx { get; set; }
    }
    public class SalesOrderItemLineDetail : SalesItemLineDetail
    {
        public bool? ManuallyClosed { get; set; }
    }
    public class ItemReceiptLineDetail
    {
        public IntuitAnyType? ItemReceiptLineDetailEx { get; set; }
    }
    public class TaxCode : IntuitEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public bool? Hidden { get; set; }
        public bool? Taxable { get; set; }
        public bool? TaxGroup { get; set; }
        public TaxRateList? SalesTaxRateList { get; set; }
        public TaxRateList? PurchaseTaxRateList { get; set; }
        public TaxRateList? AdjustmentTaxRateList { get; set; }
        public IntuitAnyType? TaxCodeEx { get; set; }
        public GTMConfigTypeEnum? TaxCodeConfigType { get; set; }
    }
    public class TaxRateDetail
    {
        public ReferenceType? TaxRateRef { get; set; }
        public TaxTypeApplicablityEnum? TaxTypeApplicable { get; set; }
        public int? TaxOrder { get; set; }
        public int? TaxOnTaxOrder { get; set; }
    }
    public class TaxRateList
    {
        public string originatingGroupId { get; set; } = default!;
        public TaxRateDetail[]? TaxRateDetail { get; set; }
    }
    public class TaxRate : IntuitEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public decimal? RateValue { get; set; }
        public ReferenceType? AgencyRef { get; set; }
        public ReferenceType? TaxReturnLineRef { get; set; }
        public EffectiveTaxRate[]? EffectiveTaxRate { get; set; }
        public SpecialTaxTypeEnum? SpecialTaxType { get; set; }
        public TaxRateDisplayTypeEnum? DisplayType { get; set; }
        public IntuitAnyType? TaxRateEx { get; set; }
    }
    public class EffectiveTaxRate
    {
        public decimal? RateValue { get; set; }
        public DateTimeOffset? EffectiveDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public IntuitAnyType? EffectiveTaxRateEx { get; set; }
    }
    public class TaxLineDetail
    {
        public ReferenceType? TaxRateRef { get; set; }
        public bool? PercentBased { get; set; }
        public decimal? TaxPercent { get; set; }
        public decimal? NetAmountTaxable { get; set; }
        public decimal? TaxInclusiveAmount { get; set; }
        public decimal? OverrideDeltaAmount { get; set; }
        public DateTime? ServiceDate { get; set; }
        public IntuitAnyType? TaxLineDetailEx { get; set; }
    }
    public class ReimburseLineDetail : ItemLineDetail
    {
    }
    public class AccountBasedExpenseLineDetail
    {
        public ReferenceType? CustomerRef { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public ReferenceType? AccountRef { get; set; }
        public BillableStatusEnum? BillableStatus { get; set; }
        public MarkupInfo? MarkupInfo { get; set; }
        public decimal? TaxAmount { get; set; }
        public ReferenceType? TaxCodeRef { get; set; }
        public decimal? TaxInclusiveAmt { get; set; }
        public IntuitAnyType? ExpenseDetailLineDetailEx { get; set; }
    }
    public class DepositLineDetail
    {
        public ReferenceType? Entity { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public ReferenceType? AccountRef { get; set; }
        public ReferenceType? PaymentMethodRef { get; set; }
        public string? CheckNum { get; set; }
        public TxnTypeEnum? TxnType { get; set; }
        public ReferenceType? TaxCodeRef { get; set; }
        public TaxApplicableOnEnum? TaxApplicableOn { get; set; }
        public IntuitAnyType? DepositLineDetailEx { get; set; }
    }
    public class JournalEntryLineDetail
    {
        public PostingTypeEnum? PostingType { get; set; }
        public EntityTypeRef? Entity { get; set; }
        public ReferenceType? AccountRef { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public ReferenceType? DepartmentRef { get; set; }
        public ReferenceType? TaxCodeRef { get; set; }
        public ReferenceType? TaxRateRef { get; set; }
        public TaxApplicableOnEnum? TaxApplicableOn { get; set; }
        public decimal? TaxAmount { get; set; }
        public decimal? TaxInclusiveAmt { get; set; }
        public BillableStatusEnum? BillableStatus { get; set; }
        public ReferenceType? JournalCodeRef { get; set; }
        public IntuitAnyType? JournalEntryLineDetailEx { get; set; }
    }
    public class PaymentLineDetail
    {
        public ReferenceType ItemRef { get; set; } = default!;
        public DateTime? ServiceDate { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public decimal? Balance { get; set; }
        public decimal? HomeBalance { get; set; }
        public DiscountOverride? Discount { get; set; }
        public IntuitAnyType? PaymentLineEx { get; set; }
    }
    public class SubTotalLineDetail
    {
        public ReferenceType? ItemRef { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
    public class EntityTypeRef
    {
        public EntityTypeEnum? Type { get; set; }
        public ReferenceType? EntityRef { get; set; }
    }
    public class MarkupInfo
    {
        public bool? PercentBased { get; set; }
        public decimal? Value { get; set; }
        public decimal? Percent { get; set; }
        public ReferenceType? PriceLevelRef { get; set; }
        public ReferenceType? MarkUpIncomeAccountRef { get; set; }
    }
    public class Account : IntuitEntity
    {
        public string? Name { get; set; }
        public bool? SubAccount { get; set; }
        public ReferenceType? ParentRef { get; set; }
        public string? Description { get; set; }
        public string? FullyQualifiedName { get; set; }
        public string? AccountAlias { get; set; }
        public string? TxnLocationType { get; set; }
        public bool? Active { get; set; }
        public AccountClassificationEnum? Classification { get; set; }
        public AccountTypeEnum? AccountType { get; set; }
        public string? AccountSubType { get; set; }
        public ReferenceType[]? AccountPurposes { get; set; }
        public string? AcctNum { get; set; }
        public string? AcctNumExtn { get; set; }
        public string? BankNum { get; set; }
        public decimal? OpeningBalance { get; set; }
        public DateTime? OpeningBalanceDate { get; set; }
        public decimal? CurrentBalance { get; set; }
        public decimal? CurrentBalanceWithSubAccounts { get; set; }
        public ReferenceType? CurrencyRef { get; set; }
        public bool? TaxAccount { get; set; }
        public ReferenceType? TaxCodeRef { get; set; }
        public bool? OnlineBankingEnabled { get; set; }
        public string? FIName { get; set; }
        public ReferenceType? JournalCodeRef { get; set; }
        public IntuitAnyType? AccountEx { get; set; }
    }
    public class MasterAccount : Account
    {
        public bool? AccountExistsInCompany { get; set; }
    }
    public class CashPurchase
    {
        public ReferenceType? AccountRef { get; set; }
    }
    public class CreditCardPurchase
    {
        public ReferenceType? AccountRef { get; set; }
        public bool? Credit { get; set; }
    }
    public class CheckPurchase
    {
        public ReferenceType? AccountRef { get; set; }
        public PhysicalAddress? PayeeAddr { get; set; }
        public string? MemoOnCheck { get; set; }
        public PrintStatusEnum? PrintStatus { get; set; }
    }
    public class CheckPayment
    {
        public string? CheckNum { get; set; }
        public string? Status { get; set; }
        public string? NameOnAcct { get; set; }
        public string? AcctNum { get; set; }
        public string? BankName { get; set; }
        public IntuitAnyType CheckPaymentEx { get; set; } = default!;
    }
    public class CreditCardPayment
    {
        public CreditChargeInfo? CreditChargeInfo { get; set; }
        public CreditChargeResponse? CreditChargeResponse { get; set; }
    }
    public class Purchase : Transaction
    {
        public ReferenceType? AccountRef { get; set; }
        public ReferenceType? PaymentMethodRef { get; set; }
        public string? PaymentRefNum { get; set; }
        public PaymentTypeEnum? PaymentType { get; set; }
        public CheckPayment? CheckPayment { get; set; }
        public CreditCardPayment? CreditCardPayment { get; set; }
        public ReferenceType? EntityRef { get; set; }
        public bool? Credit { get; set; }
        public PhysicalAddress? RemitToAddr { get; set; }
        public decimal? TotalAmt { get; set; }
        public string? TxnId { get; set; }
        public string? TxnNum { get; set; }
        public string? Memo { get; set; }
        public PrintStatusEnum? PrintStatus { get; set; }
        public GlobalTaxCalculationEnum? GlobalTaxCalculation { get; set; }
        public IntuitAnyType? PurchaseEx { get; set; }
        public decimal? LessCIS { get; set; }
        public bool? IncludeInAnnualTPAR { get; set; }
    }
    public class PurchaseByVendor : Transaction
    {
        public ReferenceType? VendorRef { get; set; }
        public ReferenceType? APAccountRef { get; set; }
        public decimal? TotalAmt { get; set; }
        public EmailAddress? BillEmail { get; set; }
        public EmailAddress? ReplyEmail { get; set; }
        public string? Memo { get; set; }
        public GlobalTaxCalculationEnum? GlobalTaxCalculation { get; set; }
    }
    public class Bill : PurchaseByVendor
    {
        public ReferenceType? PayerRef { get; set; }
        public ReferenceType? SalesTermRef { get; set; }
        public DateTime? DueDate { get; set; }
        public PhysicalAddress? RemitToAddr { get; set; }
        public PhysicalAddress? ShipAddr { get; set; }
        public PhysicalAddress? VendorAddr { get; set; }
        public decimal? Balance { get; set; }
        public decimal? HomeBalance { get; set; }
        public IntuitAnyType? BillEx { get; set; }
        public decimal? LessCIS { get; set; }
        public bool? IncludeInAnnualTPAR { get; set; }
    }
    public class VendorCredit : PurchaseByVendor
    {
        public PhysicalAddress? VendorAddr { get; set; }
        public IntuitAnyType? VendorCreditEx { get; set; }
        public decimal? Balance { get; set; }
        public bool? IncludeInAnnualTPAR { get; set; }
    }
    public class StatementCharge : Transaction
    {
        public bool? Credit { get; set; }
        public ReferenceType? CustomerRef { get; set; }
        public ReferenceType? RemitToRef { get; set; }
        public ReferenceType? ARAccountRef { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? BilledDate { get; set; }
        public decimal? TotalAmt { get; set; }
        public IntuitAnyType? StatementChargeEx { get; set; }
    }
    public class Class : IntuitEntity
    {
        public string? Name { get; set; }
        public bool? SubClass { get; set; }
        public ReferenceType? ParentRef { get; set; }
        public string? FullyQualifiedName { get; set; }
        public bool? Active { get; set; }
        public IntuitAnyType? ClassEx { get; set; }
    }
    public class JournalCode : IntuitEntity
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public IntuitAnyType? JournalCodeEx { get; set; }
    }
    public class Payment : Transaction
    {
        public ReferenceType? CustomerRef { get; set; }
        public ReferenceType? RemitToRef { get; set; }
        public ReferenceType? ARAccountRef { get; set; }
        public ReferenceType? DepositToAccountRef { get; set; }
        public ReferenceType? PaymentMethodRef { get; set; }
        public string? PaymentRefNum { get; set; }
        public PaymentTypeEnum? PaymentType { get; set; }
        public CheckPayment? CheckPayment { get; set; }
        public CreditCardPayment? CreditCardPayment { get; set; }
        public decimal? TotalAmt { get; set; }
        public decimal? UnappliedAmt { get; set; }
        public bool? ProcessPayment { get; set; }
        public IntuitAnyType? PaymentEx { get; set; }
    }
    public class PaymentMethod : IntuitEntity
    {
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public string? Type { get; set; }
        public IntuitAnyType? PaymentMethodEx { get; set; }
    }
    public class ItemComponentLine
    {
        public ReferenceType? ItemRef { get; set; }
        public decimal? Qty { get; set; }
        public UOMRef? UOMRef { get; set; }
    }
    public class ItemGroupDetail
    {
        public ItemComponentLine[]? ItemGroupLine { get; set; }
    }
    public class Department : IntuitEntity
    {
        public string? Name { get; set; }
        public bool? SubDepartment { get; set; }
        public ReferenceType? ParentRef { get; set; }
        public string? FullyQualifiedName { get; set; }
        public bool? Active { get; set; }
        public IntuitAnyType? DepartmentEx { get; set; }
        public PhysicalAddress? Address { get; set; }
    }
    public class ItemAssemblyDetail
    {
        public ItemComponentLine[]? ItemAssemblyLine { get; set; }
    }
    public class Item : IntuitEntity
    {
        public string? Name { get; set; }
        public string? Sku { get; set; }
        public string? Description { get; set; }
        public bool? Active { get; set; }
        public bool? SubItem { get; set; }
        public ReferenceType? ParentRef { get; set; }
        public int? Level { get; set; }
        public string? FullyQualifiedName { get; set; }
        public bool? Taxable { get; set; }
        public bool? SalesTaxIncluded { get; set; }
        public bool? PercentBased { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? RatePercent { get; set; }
        public ItemTypeEnum? Type { get; set; }
        public ReferenceType? PaymentMethodRef { get; set; }
        public ReferenceType? UOMSetRef { get; set; }
        public ReferenceType? IncomeAccountRef { get; set; }
        public string? PurchaseDesc { get; set; }
        public bool? PurchaseTaxIncluded { get; set; }
        public decimal? PurchaseCost { get; set; }
        public ReferenceType? ExpenseAccountRef { get; set; }
        public ReferenceType? COGSAccountRef { get; set; }
        public ReferenceType? AssetAccountRef { get; set; }
        public ReferenceType? PrefVendorRef { get; set; }
        public decimal? AvgCost { get; set; }
        public bool? TrackQtyOnHand { get; set; }
        public decimal? QtyOnHand { get; set; }
        public decimal? QtyOnPurchaseOrder { get; set; }
        public decimal? QtyOnSalesOrder { get; set; }
        public decimal? ReorderPoint { get; set; }
        public string? ManPartNum { get; set; }
        public ReferenceType? DepositToAccountRef { get; set; }
        public ReferenceType? SalesTaxCodeRef { get; set; }
        public ReferenceType? PurchaseTaxCodeRef { get; set; }
        public DateTime? InvStartDate { get; set; }
        public decimal? BuildPoint { get; set; }
        public bool? PrintGroupedItems { get; set; }
        public bool? SpecialItem { get; set; }
        public SpecialItemTypeEnum? SpecialItemType { get; set; }
        public ItemGroupDetail? ItemGroupDetail { get; set; }
        public ItemAssemblyDetail? ItemAssemblyDetail { get; set; }
        public decimal? AbatementRate { get; set; }
        public decimal? ReverseChargeRate { get; set; }
        public string? ServiceType { get; set; }
        public string? ItemCategoryType { get; set; }
        public IntuitAnyType? ItemEx { get; set; }
        public ReferenceType? TaxClassificationRef { get; set; }
        public string? UQCDisplayText { get; set; }
        public string? UQCId { get; set; }
        public ReferenceType? ClassRef { get; set; }
    }
    public class Term : IntuitEntity
    {
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public string? Type { get; set; }
        public decimal? DiscountPercent { get; set; }
        public int? DueDays { get; set; }
        public int? DiscountDays { get; set; }
        public uint? DayOfMonthDue { get; set; }
        public uint? DueNextMonthDays { get; set; }
        public uint? DiscountDayOfMonth { get; set; }
        public IntuitAnyType? SalesTermEx { get; set; }
    }
    public class BillPaymentCheck
    {
        public ReferenceType? BankAccountRef { get; set; }
        public PrintStatusEnum? PrintStatus { get; set; }
        public CheckPayment? CheckDetail { get; set; }
        public PhysicalAddress? PayeeAddr { get; set; }
        public IntuitAnyType? BillPaymentCheckEx { get; set; }
    }
    public class BillPaymentCreditCard
    {
        public ReferenceType? CCAccountRef { get; set; }
        public CreditCardPayment? CCDetail { get; set; }
        public IntuitAnyType? BillPaymentCreditCardEx { get; set; }
    }
    public class BillPayment : Transaction
    {
        public ReferenceType? VendorRef { get; set; }
        public PhysicalAddress? VendorAddr { get; set; }
        public ReferenceType? APAccountRef { get; set; }
        public BillPaymentTypeEnum? PayType { get; set; }
        public BillPaymentCheck? CheckPayment { get; set; }
        public BillPaymentCreditCard? CreditCardPayment { get; set; }
        public decimal? TotalAmt { get; set; }
        public IntuitAnyType? BillPaymentEx { get; set; }
    }
    public class CashBackInfo
    {
        public ReferenceType? AccountRef { get; set; }
        public decimal? Amount { get; set; }
        public string? Memo { get; set; }
    }
    public class Deposit : Transaction
    {
        public ReferenceType? DepositToAccountRef { get; set; }
        public CashBackInfo? CashBack { get; set; }
        public GlobalTaxCalculationEnum? GlobalTaxCalculation { get; set; }
        public decimal? TotalAmt { get; set; }
        public decimal? HomeTotalAmt { get; set; }
        public IntuitAnyType? DepositEx { get; set; }
    }
    public class Transfer : Transaction
    {
        public ReferenceType? FromAccountRef { get; set; }
        public ReferenceType? ToAccountRef { get; set; }
        public decimal? Amount { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public IntuitAnyType TransferEx { get; set; } = default!;
    }
    public class PurchaseOrder : PurchaseByVendor
    {
        public ReferenceType? TaxCodeRef { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public ReferenceType? ReimbursableInfoRef { get; set; }
        public ReferenceType? SalesTermRef { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public PhysicalAddress? VendorAddr { get; set; }
        public ReferenceType? ShipTo { get; set; }
        public ReferenceType? DropShipToEntity { get; set; }
        public ReferenceType? InventorySiteRef { get; set; }
        public PhysicalAddress? ShipAddr { get; set; }
        public ReferenceType? ShipMethodRef { get; set; }
        public string? FOB { get; set; }
        public EmailAddress? POEmail { get; set; }
        public ReferenceType? TemplateRef { get; set; }
        public PrintStatusEnum? PrintStatus { get; set; }
        public EmailStatusEnum? EmailStatus { get; set; }
        public bool? ManuallyClosed { get; set; }
        public PurchaseOrderStatusEnum? POStatus { get; set; }
        public IntuitAnyType? PurchaseOrderEx { get; set; }
    }
    public class SalesOrder : SalesTransaction
    {
        public bool? ManuallyClosed { get; set; }
        public IntuitAnyType? SalesOrderEx { get; set; }
    }
    public class CreditMemo : SalesTransaction
    {
        public decimal? RemainingCredit { get; set; }
        public ReferenceType? InvoiceRef { get; set; }
        public IntuitAnyType? CreditMemoEx { get; set; }
    }
    public class RefundReceipt : SalesTransaction
    {
        public decimal? RemainingCredit { get; set; }
        public IntuitAnyType? RefundReceiptEx { get; set; }
    }
    public class CreditCardPaymentTxn : Transaction
    {
        public ReferenceType? CreditCardAccountRef { get; set; }
        public ReferenceType? BankAccountRef { get; set; }
        public decimal? Amount { get; set; }
        public ReferenceType? VendorRef { get; set; }
        public string? CheckNum { get; set; }
        public PrintStatusEnum? PrintStatus { get; set; }
        public string? Memo { get; set; }
        public IntuitAnyType CreditCardPaymentEx { get; set; } = default!;
    }
    public class Currency : IntuitEntity
    {
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public currencyCode? Code { get; set; }
        public string? Separator { get; set; }
        public string? Format { get; set; }
        public uint? DecimalPlaces { get; set; }
        public string? DecimalSeparator { get; set; }
        public string? Symbol { get; set; }
        public SymbolPositionEnum? SymbolPosition { get; set; }
        public bool? UserDefined { get; set; }
        public decimal? ExchangeRate { get; set; }
        public DateTime? AsOfDate { get; set; }
        public IntuitAnyType? CurrencyEx { get; set; }
    }
    public class CompanyCurrency : IntuitEntity
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public IntuitAnyType? CompanyCurrencyEx { get; set; }
    }
    public class ExchangeRate : IntuitEntity
    {
        public string? SourceCurrencyCode { get; set; }
        public string? TargetCurrencyCode { get; set; }
        public decimal? Rate { get; set; }
        public DateTime? AsOfDate { get; set; }
        public IntuitAnyType? ExchangeRateEx { get; set; }
    }
    public class SalesRep : IntuitEntity
    {
        public SalesRepTypeEnum? NameOf { get; set; }
        public bool? Active { get; set; }
        public ReferenceType? EmployeeRef { get; set; }
        public ReferenceType? VendorRef { get; set; }
        public ReferenceType? OtherNameRef { get; set; }
        public string? Initials { get; set; }
        public IntuitAnyType? SalesRepEx { get; set; }
    }
    public class PriceLevel : IntuitEntity
    {
        public object Name { get; set; } = default!;
        public bool Active { get; set; } = default!;
        public PriceLevelTypeEnum PriceLevelType { get; set; } = default!;
        public decimal? FixedPercentage { get; set; }
        public PriceLevelPerItem[]? PriceLevelPerItem { get; set; }
        public ReferenceType? CurrencyRef { get; set; }
        public IntuitAnyType? PriceLevelEx { get; set; }
    }
    public class PriceLevelPerItem : IntuitEntity
    {
        public ReferenceType? ItemRef { get; set; }
        public decimal? CustomPrice { get; set; }
        public decimal? CustomPricePercent { get; set; }
        public IntuitAnyType? PriceLevelPerItemEx { get; set; }
    }
    public class CustomerMsg : IntuitEntity
    {
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public IntuitAnyType? CustomerMsgEx { get; set; }
    }
    public class JournalEntry : Transaction
    {
        public bool? Adjustment { get; set; }
        public bool? HomeCurrencyAdjustment { get; set; }
        public bool? EnteredInHomeCurrency { get; set; }
        public GlobalTaxCalculationEnum? GlobalTaxCalculation { get; set; }
        public decimal? TotalAmt { get; set; }
        public decimal? HomeTotalAmt { get; set; }
        public IntuitAnyType? JournalEntryEx { get; set; }
    }
    public class TimeActivity : IntuitEntity
    {
        public string? TimeZone { get; set; }
        public DateTime? TxnDate { get; set; }
        public TimeActivityTypeEnum? NameOf { get; set; }
        public ReferenceType? EmployeeRef { get; set; }
        public ReferenceType? VendorRef { get; set; }
        public ReferenceType? OtherNameRef { get; set; }
        public ReferenceType? CustomerRef { get; set; }
        public ReferenceType? DepartmentRef { get; set; }
        public ReferenceType? ItemRef { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public ReferenceType? PayrollItemRef { get; set; }
        public BillableStatusEnum? BillableStatus { get; set; }
        public bool? Taxable { get; set; }
        public decimal? HourlyRate { get; set; }
        public int? Hours { get; set; }
        public int? Minutes { get; set; }
        public int? BreakHours { get; set; }
        public int? BreakMinutes { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string? Description { get; set; }
        public IntuitAnyType? TimeActivityEx { get; set; }
        public bool? HoursInEmployeeTimeZone { get; set; }
    }
    public class InventorySite : IntuitEntity
    {
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public bool? DefaultSite { get; set; }
        public string? Description { get; set; }
        public string? Contact { get; set; }
        public PhysicalAddress[]? Addr { get; set; }
        public ContactInfo[]? ContactInfo { get; set; }
        public IntuitAnyType? InventorySiteEx { get; set; }
    }
    public class ShipMethod : IntuitEntity
    {
        public string? Name { get; set; }
        public bool Active { get; set; } = default!;
        public IntuitAnyType? ShipMethodEx { get; set; }
    }
    public class MemoRef
    {
        public string value { get; set; } = default!;
        public string id { get; set; } = default!;
    }
    public class QbTask : IntuitEntity
    {
        public string? Notes { get; set; }
        public string? From { get; set; }
        public bool? Active { get; set; }
        public bool? Done { get; set; }
        public DateTime? ReminderDate { get; set; }
        public IntuitAnyType? TaskEx { get; set; }
    }
    public class UserAlert : IntuitEntity
    {
        public string? Notes { get; set; }
        public bool? Active { get; set; }
        public bool? Done { get; set; }
        public string? Type { get; set; }
        public DateTimeOffset? ReminderDate { get; set; }
        public DateTimeOffset? ExpireDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? URL { get; set; }
        public string? Filter { get; set; }
        public NameValue[]? NameValue { get; set; }
        public IntuitAnyType? UserAlertEx { get; set; }
    }
    public class CurrencyPrefs
    {
        public bool? MultiCurrencyEnabled { get; set; }
        public ReferenceType? HomeCurrency { get; set; }
    }
    public class TaxPrefs
    {
        public bool? UsingSalesTax { get; set; }
        public bool? PartnerTaxEnabled { get; set; }
        public bool? HideTaxManagement { get; set; }
        public ReferenceType? TaxGroupCodeRef { get; set; }
        public ReferenceType? TaxRateRef { get; set; }
        public PaySalesTaxEnum? PaySalesTax { get; set; }
        public ReferenceType? NonTaxableSalesTaxCodeRef { get; set; }
        public ReferenceType? TaxableSalesTaxCodeRef { get; set; }
    }
    public class FinanceChargePrefs
    {
        public decimal? AnnualInterestRate { get; set; }
        public decimal? MinFinChrg { get; set; }
        public uint? GracePeriod { get; set; }
        public bool? CalcFinChrgFromTxnDate { get; set; }
        public bool? AssessFinChrgForOverdueCharges { get; set; }
        public ReferenceType? FinChrgAccountRef { get; set; }
    }
    public class CompanyAccountingPrefs
    {
        public bool? UseAccountNumbers { get; set; }
        public ReferenceType? DefaultARAccount { get; set; }
        public ReferenceType? DefaultAPAccount { get; set; }
        public bool? RequiresAccounts { get; set; }
        public bool? TrackDepartments { get; set; }
        public string? DepartmentTerminology { get; set; }
        public bool? ClassTrackingPerTxn { get; set; }
        public bool? ClassTrackingPerTxnLine { get; set; }
        public bool? AutoJournalEntryNumber { get; set; }
        public MonthEnum? FirstMonthOfFiscalYear { get; set; }
        public MonthEnum? TaxYearMonth { get; set; }
        public string? TaxForm { get; set; }
        public DateTime? BookCloseDate { get; set; }
        public ContactInfo[]? OtherContactInfo { get; set; }
        public string? CustomerTerminology { get; set; }
    }
    public class AdvancedInventoryPrefs
    {
        public bool? MLIAvailable { get; set; }
        public bool? MLIEnabled { get; set; }
        public bool? EnhancedInventoryReceivingEnabled { get; set; }
        public bool? TrackingSerialOrLotNumber { get; set; }
        public bool? TrackingOnSalesTransactionsEnabled { get; set; }
        public bool? TrackingOnPurchaseTransactionsEnabled { get; set; }
        public bool? TrackingOnInventoryAdjustmentEnabled { get; set; }
        public bool? TrackingOnBuildAssemblyEnabled { get; set; }
        public bool? FIFOEnabled { get; set; }
        public DateTime? FIFOEffectiveDate { get; set; }
        public bool? RowShelfBinEnabled { get; set; }
        public bool? BarcodeEnabled { get; set; }
    }
    public class ProductAndServicesPrefs
    {
        public bool? ForSales { get; set; }
        public bool? ForPurchase { get; set; }
        public bool? InventoryAndPurchaseOrder { get; set; }
        public bool? QuantityWithPriceAndRate { get; set; }
        public bool? QuantityOnHand { get; set; }
        public UOMFeatureTypeEnum? UOM { get; set; }
    }
    public class SalesFormsPrefs
    {
        public bool? UsingProgressInvoicing { get; set; }
        public CustomFieldDefinition[]? CustomField { get; set; }
        public bool? CustomTxnNumbers { get; set; }
        public bool? DelayedCharges { get; set; }
        public EmailAddress? SalesEmailCc { get; set; }
        public EmailAddress? SalesEmailBcc { get; set; }
        public bool? EmailCopyToCompany { get; set; }
        public bool? AllowDeposit { get; set; }
        public bool? AllowDiscount { get; set; }
        public string? DefaultDiscountAccount { get; set; }
        public bool? AllowEstimates { get; set; }
        public string? EstimateMessage { get; set; }
        public ETransactionEnabledStatusEnum? ETransactionEnabledStatus { get; set; }
        public bool? ETransactionAttachPDF { get; set; }
        public bool? ETransactionPaymentEnabled { get; set; }
        public bool? IPNSupportEnabled { get; set; }
        public string? InvoiceMessage { get; set; }
        public bool? AllowServiceDate { get; set; }
        public bool? AllowShipping { get; set; }
        public string? DefaultShippingAccount { get; set; }
        public ReferenceType? DefaultItem { get; set; }
        public ReferenceType? DefaultTerms { get; set; }
        public string? DefaultDeliveryMethod { get; set; }
        public bool? AutoApplyCredit { get; set; }
        public bool? AutoApplyPayments { get; set; }
        public bool? PrintItemWithZeroAmount { get; set; }
        public ReferenceType? DefaultShipMethodRef { get; set; }
        public decimal? DefaultMarkup { get; set; }
        public bool? TrackReimbursableExpensesAsIncome { get; set; }
        public bool? UsingSalesOrders { get; set; }
        public bool? UsingPriceLevels { get; set; }
        public string? DefaultFOB { get; set; }
        public string? DefaultCustomerMessage { get; set; }
    }
    public class VendorAndPurchasesPrefs
    {
        public bool? EnableBills { get; set; }
        public bool? TrackingByCustomer { get; set; }
        public bool? BillableExpenseTracking { get; set; }
        public ReferenceType? DefaultTerms { get; set; }
        public decimal? DefaultMarkup { get; set; }
        public ReferenceType? DefaultMarkupAccount { get; set; }
        public bool? AutomaticBillPayment { get; set; }
        public bool? TPAREnabled { get; set; }
        public CustomFieldDefinition[]? POCustomField { get; set; }
        public string? MsgToVendors { get; set; }
        public bool? UsingInventory { get; set; }
        public bool? UsingMultiLocationInventory { get; set; }
        public int? DaysBillsAreDue { get; set; }
        public ReferenceType? DiscountAccountRef { get; set; }
    }
    public class TimeTrackingPrefs
    {
        public bool? UseServices { get; set; }
        public ReferenceType? DefaultTimeItem { get; set; }
        public bool? BillCustomers { get; set; }
        public bool? ShowBillRateToAll { get; set; }
        public WeekEnum? WorkWeekStartDate { get; set; }
        public bool? TimeTrackingEnabled { get; set; }
        public bool? MarkTimeEntriesBillable { get; set; }
        public bool? MarkExpensesAsBillable { get; set; }
    }
    public class EmailMessagesPrefs
    {
        public NameValue[]? NameValue { get; set; }
        public EmailMessage? InvoiceMessage { get; set; }
        public EmailMessage? EstimateMessage { get; set; }
        public EmailMessage? SalesReceiptMessage { get; set; }
        public EmailMessage? StatementMessage { get; set; }
    }
    public class PrintDocumentPrefs
    {
        public NameValue[]? NameValue { get; set; }
    }
    public class ReportPrefs
    {
        public ReportBasisEnum? ReportBasis { get; set; }
        public bool? CalcAgingReportFromTxnDate { get; set; }
    }
    public class OtherPrefs
    {
        public NameValue[]? NameValue { get; set; }
    }
    public class Preferences : IntuitEntity
    {
        public CompanyAccountingPrefs? AccountingInfoPrefs { get; set; }
        public AdvancedInventoryPrefs? AdvancedInventoryPrefs { get; set; }
        public ProductAndServicesPrefs? ProductAndServicesPrefs { get; set; }
        public SalesFormsPrefs? SalesFormsPrefs { get; set; }
        public EmailMessagesPrefs? EmailMessagesPrefs { get; set; }
        public PrintDocumentPrefs? PrintDocumentPrefs { get; set; }
        public VendorAndPurchasesPrefs? VendorAndPurchasesPrefs { get; set; }
        public TimeTrackingPrefs? TimeTrackingPrefs { get; set; }
        public TaxPrefs? TaxPrefs { get; set; }
        public FinanceChargePrefs? FinanceChargesPrefs { get; set; }
        public CurrencyPrefs? CurrencyPrefs { get; set; }
        public ReportPrefs? ReportPrefs { get; set; }
        public OtherPrefs? OtherPrefs { get; set; }
    }
    public class UOMRef
    {
        public string Unit { get; set; } = default!;
        public ReferenceType UOMSetRef { get; set; } = default!;
    }
    public class UOM : IntuitEntity
    {
        public string? Name { get; set; }
        public string? Abbrv { get; set; }
        public UOMBaseTypeEnum? BaseType { get; set; }
        public UOMConvUnit[]? ConvUnit { get; set; }
    }
    public class UOMConvUnit
    {
        public string? Name { get; set; }
        public string? Abbrv { get; set; }
        public decimal? ConvRatio { get; set; }
    }
    public class TemplateName : IntuitEntity
    {
        public string? Name { get; set; }
        public bool? Active { get; set; }
        public TemplateTypeEnum? Type { get; set; }
    }
    public class Attachable : IntuitEntity
    {
        public string? FileName { get; set; }
        public string? FileAccessUri { get; set; }
        public string? TempDownloadUri { get; set; }
        public long? Size { get; set; }
        public string? ContentType { get; set; }
        public string? Category { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public string? PlaceName { get; set; }
        public string? Note { get; set; }
        public string? Tag { get; set; }
        public string? ThumbnailFileAccessUri { get; set; }
        public string? ThumbnailTempDownloadUri { get; set; }
        public IntuitAnyType? AttachableEx { get; set; }
    }
    public class RecurringScheduleInfo
    {
        public string? IntervalType { get; set; }
        public int? NumInterval { get; set; }
        public int? DayOfMonth { get; set; }
        public WeekEnum? DayOfWeek { get; set; }
        public int? WeekOfMonth { get; set; }
        public MonthEnum? MonthOfYear { get; set; }
        public int? RemindDays { get; set; }
        public int? DaysBefore { get; set; }
        public int? MaxOccurrences { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? NextDate { get; set; }
        public DateTime? PreviousDate { get; set; }
    }
    public class RecurringInfo
    {
        public string? Name { get; set; }
        public string? RecurType { get; set; }
        public bool? Active { get; set; }
        public RecurringScheduleInfo? ScheduleInfo { get; set; }
    }
    public class OLBTxnDetail
    {
        public DateTime? PostDate { get; set; }
        public DateTime? TxnDate { get; set; }
        public decimal? Amount { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? TxnStatus { get; set; }
    }
    public class OLBTxn
    {
        public int? startPosition { get; set; }
        public int? maxResults { get; set; }
        public int? totalCount { get; set; }
        public ReferenceType? AccountId { get; set; }
        public DateTime? LastPostingDate { get; set; }
        public DateTimeOffset? TxnsDownloadTime { get; set; }
        public OLBTxnDetail[]? OLBTxnDetail { get; set; }
    }
    public class OLBTransaction
    {
        public DateTimeOffset? OLBDownloadTime { get; set; }
        public OLBTxn[]? OLBTxn { get; set; }
    }
    public class OLBAccount
    {
        public ReferenceType? AccountId { get; set; }
        public string? AccountDetails { get; set; }
        public bool? SubscribedToApp { get; set; }
        public string? AppVersion { get; set; }
        public decimal? LastBankBalance { get; set; }
    }
    public class OLBStatus
    {
        public OLBAccount[]? OLBAccount { get; set; }
    }
    public class Budget : IntuitEntity
    {
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public BudgetTypeEnum? BudgetType { get; set; }
        public BudgetEntryTypeEnum? BudgetEntryType { get; set; }
        public bool? Active { get; set; }
        public BudgetDetail[]? BudgetDetail { get; set; }
    }
    public class BudgetDetail
    {
        public DateTime? BudgetDate { get; set; }
        public decimal? Amount { get; set; }
        public ReferenceType? AccountRef { get; set; }
        public ReferenceType? CustomerRef { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public ReferenceType? DepartmentRef { get; set; }
    }
    public class TDSMetadata : IntuitEntity
    {
        public NameValue[]? TDSEntityTypes { get; set; }
        public NameValue[]? TDSSectionTypes { get; set; }
    }
    public class ReimburseCharge : Transaction
    {
        public ReferenceType? CustomerRef { get; set; }
        public bool? HasBeenInvoiced { get; set; }
        public decimal? Amount { get; set; }
        public decimal? HomeTotalAmt { get; set; }
    }
    public class ChargeCredit : Transaction
    {
        public bool? Credit { get; set; }
        public ReferenceType? CustomerRef { get; set; }
        public ReferenceType? RemitToRef { get; set; }
        public ReferenceType? ARAccountRef { get; set; }
        public ReferenceType? ClassRef { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? BilledDate { get; set; }
        public decimal? TotalAmt { get; set; }
        public IntuitAnyType? ChargeCreditEx { get; set; }
    }
    public class TaxReturn : IntuitEntity
    {
        public bool? UpcomingFiling { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? FileDate { get; set; }
        public DateTime? AgencyPaymentDate { get; set; }
        public decimal? AgencyPaymentAmount { get; set; }
        public decimal? NetTaxAmountDue { get; set; }
        public decimal? FlatRateSavingsAmountDue { get; set; }
        public decimal? PayGWithheldAmount { get; set; }
        public ReferenceType? AgencyRef { get; set; }
        public TaxReturnStatusEnum? TaxReturnStatus { get; set; }
        public string? TaxReturnEFilingFailureReason { get; set; }
        public DateTime? EFileErrorFixByDate { get; set; }
        public AgencyPaymentMethodEnum? AgencyPaymentMethod { get; set; }
        public string? TaxReturnCode { get; set; }
    }
    public class StatusInfo
    {
        public string? status { get; set; }
        public DateTime? statusDate { get; set; }
        public string? callToAction { get; set; }
    }
    public class TaxClassification : IntuitEntity
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Level { get; set; }
        public ReferenceType? ParentRef { get; set; }
        public ItemTypeEnum[]? ApplicableTo { get; set; }
    }
    public class TaxPayment : IntuitEntity
    {
        public DateTime? PaymentDate { get; set; }
        public ReferenceType? PaymentAccountRef { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string? Description { get; set; }
        public bool? Refund { get; set; }
    }
    public abstract class IntuitEntity
    {
        public string? domain { get; set; }
        public EntityStatusEnum? status { get; set; }
        public bool? sparse { get; set; }
        public string? Id { get; set; }
        public string? SyncToken { get; set; }
        public ModificationMetaData? MetaData { get; set; }
        public CustomField[]? CustomField { get; set; }
        public AttachableRef[]? AttachableRef { get; set; }
    }
    public class CustomField
    {
        public string? DefinitionId { get; set; }
        public string? Name { get; set; }
        public CustomFieldTypeEnum Type { get; set; } = default!;
        public string? StringValue { get; set; }
        public bool? BooleanValue { get; set; }
        public DateTime? DateValue { get; set; }
        public decimal? NumberValue { get; set; }
    }
    public class AttachableRef
    {
        public ReferenceType? EntityRef { get; set; }
        public string? LineInfo { get; set; }
        public bool? IncludeOnSend { get; set; }
        public CustomField[]? CustomField { get; set; }
        public IntuitAnyType? AttachableRefEx { get; set; }
    }
    public class CustomFieldDefinition : IntuitEntity
    {
        public string? EntityType { get; set; }
        public string? Name { get; set; }
        public bool? Hidden { get; set; }
        public bool? Required { get; set; }
        public string? AppId { get; set; }
    }
    public class StringTypeCustomFieldDefinition : CustomFieldDefinition
    {
        public string? DefaultString { get; set; }
        public string? RegularExpression { get; set; }
        public int? MaxLength { get; set; }
    }
    public class NumberTypeCustomFieldDefinition : CustomFieldDefinition
    {
        public decimal? DefaultValue { get; set; }
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }
    }
    public class DateTypeCustomFieldDefinition : CustomFieldDefinition
    {
        public DateTime? DefaultDate { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
    }
    public class BooleanTypeCustomFieldDefinition : CustomFieldDefinition
    {
        public bool? DefaultValue { get; set; }
    }
    public class NameValue
    {
        public string? Name { get; set; }
        public string? Value { get; set; }
    }
    public class ModificationMetaData
    {
        public ReferenceType? CreatedByRef { get; set; }
        public DateTimeOffset? CreateTime { get; set; }
        public ReferenceType? LastModifiedByRef { get; set; }
        public DateTimeOffset? LastUpdatedTime { get; set; }
        public DateTimeOffset? LastChangedInQB { get; set; }
        public bool? Synchronized { get; set; }
    }
    public class Money
    {
        public string? CurCode { get; set; }
        public decimal? Amount { get; set; }
    }
    public class ContactInfo
    {
        public ContactTypeEnum? Type { get; set; }
        public TelephoneNumber? Telephone { get; set; }
        public EmailAddress? Email { get; set; }
        public WebSiteAddress? WebSite { get; set; }
        public GenericContactType? OtherContact { get; set; }
    }
    public class PhysicalAddress
    {
        public string? Id { get; set; }
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string? Line4 { get; set; }
        public string? Line5 { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? CountryCode { get; set; }
        public string? County { get; set; }
        public string? CountrySubDivisionCode { get; set; }
        public string? PostalCode { get; set; }
        public string? PostalCodeSuffix { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public string? Tag { get; set; }
        public string? Note { get; set; }
    }
    public class TelephoneNumber
    {
        public string? Id { get; set; }
        public string? DeviceType { get; set; }
        public string? CountryCode { get; set; }
        public string? AreaCode { get; set; }
        public string? ExchangeCode { get; set; }
        public string? Extension { get; set; }
        public string? FreeFormNumber { get; set; }
        public bool? Default { get; set; }
        public string? Tag { get; set; }
    }
    public class EmailAddress
    {
        public string? Id { get; set; }
        public string? Address { get; set; }
        public bool? Default { get; set; }
        public string? Tag { get; set; }
    }
    public class EmailMessage
    {
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
    public class TransactionDeliveryInfo
    {
        public DeliveryTypeEnum? DeliveryType { get; set; }
        public DateTimeOffset? DeliveryTime { get; set; }
        public DeliveryErrorTypeEnum? DeliveryErrorType { get; set; }
    }
    public class GenericContactType
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Type { get; set; }
        public bool? Default { get; set; }
        public string? Tag { get; set; }
    }
    public class WebSiteAddress
    {
        public string? Id { get; set; }
        public string? URI { get; set; }
        public bool? Default { get; set; }
        public string? Tag { get; set; }
    }
    public class IntuitAnyType
    {
    }
    public class CreditChargeInfo
    {
        public string? Number { get; set; }
        public string? Type { get; set; }
        public string? NameOnAcct { get; set; }
        public int? CcExpiryMonth { get; set; }
        public int? CcExpiryYear { get; set; }
        public string? BillAddrStreet { get; set; }
        public string? PostalCode { get; set; }
        public string? CommercialCardCode { get; set; }
        public CCTxnModeEnum? CCTxnMode { get; set; }
        public CCTxnTypeEnum? CCTxnType { get; set; }
        public string? PrevCCTransId { get; set; }
        public decimal? Amount { get; set; }
        public bool? ProcessPayment { get; set; }
        public IntuitAnyType? CreditCardChargeInfoEx { get; set; }
    }
    public class CreditChargeResponse
    {
        public string? CCProcessor { get; set; }
        public string? CCTransId { get; set; }
        public CCPaymentStatusEnum? Status { get; set; }
        public int? ResultCode { get; set; }
        public string? ResultMsg { get; set; }
        public string? MerchantAcctNum { get; set; }
        public CCSecurityCodeMatchEnum? CardSecurityCodeMatch { get; set; }
        public string? AuthCode { get; set; }
        public CCAVSMatchEnum? AvsStreet { get; set; }
        public CCAVSMatchEnum? AvsZip { get; set; }
        public string? SecurityCode { get; set; }
        public string? ReconBatchId { get; set; }
        public int? PaymentGroupingCode { get; set; }
        public DateTimeOffset? TxnAuthorizationTime { get; set; }
        public int? TxnAuthorizationStamp { get; set; }
        public string? ClientTransID { get; set; }
        public IntuitAnyType? CreditChargeResponseEx { get; set; }
    }
    public class ReferenceType
    {
        public string value { get; set; } = default!;
        public string? name { get; set; }
        public string? type { get; set; }
    }
    public class NameBase : IntuitEntity
    {
        public string? IntuitId { get; set; }
        public bool? Organization { get; set; }
        public string? Title { get; set; }
        public string? GivenName { get; set; }
        public string? MiddleName { get; set; }
        public string? FamilyName { get; set; }
        public string? Suffix { get; set; }
        public string? FullyQualifiedName { get; set; }
        public string? CompanyName { get; set; }
        public string? DisplayName { get; set; }
        public string? PrintOnCheckName { get; set; }
        public string? UserId { get; set; }
        public bool? Active { get; set; }
        public string? V4IDPseudonym { get; set; }
        public TelephoneNumber? PrimaryPhone { get; set; }
        public TelephoneNumber? AlternatePhone { get; set; }
        public TelephoneNumber? Mobile { get; set; }
        public TelephoneNumber? Fax { get; set; }
        public EmailAddress? PrimaryEmailAddr { get; set; }
        public WebSiteAddress? WebAddr { get; set; }
        public ContactInfo[]? OtherContactInfo { get; set; }
        public ReferenceType? DefaultTaxCodeRef { get; set; }
    }
    public class Customer : NameBase
    {
        public bool? Taxable { get; set; }
        public PhysicalAddress? BillAddr { get; set; }
        public PhysicalAddress? ShipAddr { get; set; }
        public PhysicalAddress[]? OtherAddr { get; set; }
        public string? ContactName { get; set; }
        public string? AltContactName { get; set; }
        public string? Notes { get; set; }
        public bool? Job { get; set; }
        public bool? BillWithParent { get; set; }
        public ReferenceType? RootCustomerRef { get; set; }
        public ReferenceType? ParentRef { get; set; }
        public int? Level { get; set; }
        public ReferenceType? CustomerTypeRef { get; set; }
        public ReferenceType? SalesTermRef { get; set; }
        public ReferenceType? SalesRepRef { get; set; }
        public ReferenceType? TaxGroupCodeRef { get; set; }
        public ReferenceType? TaxRateRef { get; set; }
        public ReferenceType? PaymentMethodRef { get; set; }
        public CreditChargeInfo? CCDetail { get; set; }
        public ReferenceType? PriceLevelRef { get; set; }
        public decimal? Balance { get; set; }
        public DateTime? OpenBalanceDate { get; set; }
        public decimal? BalanceWithJobs { get; set; }
        public decimal? CreditLimit { get; set; }
        public string? AcctNum { get; set; }
        public ReferenceType? CurrencyRef { get; set; }
        public decimal? OverDueBalance { get; set; }
        public decimal? TotalRevenue { get; set; }
        public decimal? TotalExpense { get; set; }
        public string? PreferredDeliveryMethod { get; set; }
        public string? ResaleNum { get; set; }
        public JobInfo? JobInfo { get; set; }
        public bool? TDSEnabled { get; set; }
        public IntuitAnyType? CustomerEx { get; set; }
        public string? SecondaryTaxIdentifier { get; set; }
        public ReferenceType? ARAccountRef { get; set; }
        public string? PrimaryTaxIdentifier { get; set; }
        public string? TaxExemptionReasonId { get; set; }
        public bool? IsProject { get; set; }
        public string? BusinessNumber { get; set; }
        public string? GSTIN { get; set; }
        public string? GSTRegistrationType { get; set; }
        public bool? IsCISContractor { get; set; }
        public string? ClientCompanyId { get; set; }
        public string? ClientEntityId { get; set; }
    }
    public class User : IntuitEntity
    {
        public string? DisplayName { get; set; }
        public string? Title { get; set; }
        public string? GivenName { get; set; }
        public string? MiddleName { get; set; }
        public string? FamilyName { get; set; }
        public string? Suffix { get; set; }
        public EmailAddress[]? EmailAddr { get; set; }
        public PhysicalAddress[]? Addr { get; set; }
        public TelephoneNumber[] PhoneNumber { get; set; } = default!;
        public string? LocaleCountry { get; set; }
        public string? LocaleLanguage { get; set; }
        public string? LocalePostalCode { get; set; }
        public string? LocaleTimeZone { get; set; }
        public NameValue[]? NameValueAttr { get; set; }
    }
    public class Vendor : NameBase
    {
        public string? ContactName { get; set; }
        public string? AltContactName { get; set; }
        public string? Notes { get; set; }
        public PhysicalAddress? BillAddr { get; set; }
        public PhysicalAddress? ShipAddr { get; set; }
        public PhysicalAddress[]? OtherAddr { get; set; }
        public string? TaxCountry { get; set; }
        public string? TaxIdentifier { get; set; }
        public DateTime? TaxIdEffectiveDate { get; set; }
        public string? BusinessNumber { get; set; }
        public ReferenceType? ParentRef { get; set; }
        public ReferenceType? VendorTypeRef { get; set; }
        public ReferenceType? TermRef { get; set; }
        public ReferenceType? PrefillAccountRef { get; set; }
        public decimal? Balance { get; set; }
        public decimal? BillRate { get; set; }
        public DateTime? OpenBalanceDate { get; set; }
        public decimal? CreditLimit { get; set; }
        public string? AcctNum { get; set; }
        public bool? Vendor1099 { get; set; }
        public bool? T4AEligible { get; set; }
        public bool? T5018Eligible { get; set; }
        public ReferenceType? CurrencyRef { get; set; }
        public bool? TDSEnabled { get; set; }
        public int? TDSEntityTypeId { get; set; }
        public int? TDSSectionTypeId { get; set; }
        public bool? TDSOverrideThreshold { get; set; }
        public string? TaxReportingBasis { get; set; }
        public ReferenceType? APAccountRef { get; set; }
        public IntuitAnyType? VendorEx { get; set; }
        public string? GSTIN { get; set; }
        public string? GSTRegistrationType { get; set; }
        public bool? IsSubContractor { get; set; }
        public string? SubcontractorType { get; set; }
        public string? CISRate { get; set; }
        public bool? HasTPAR { get; set; }
        public VendorBankAccountDetail? VendorPaymentBankDetail { get; set; }
    }
    public class CustomerType : IntuitEntity
    {
        public string? Name { get; set; }
        public ReferenceType? ParentRef { get; set; }
        public string? FullyQualifiedName { get; set; }
        public bool? Active { get; set; }
    }
    public class Employee : NameBase
    {
        public string? EmployeeType { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? SSN { get; set; }
        public PhysicalAddress? PrimaryAddr { get; set; }
        public PhysicalAddress[]? OtherAddr { get; set; }
        public bool? BillableTime { get; set; }
        public decimal? BillRate { get; set; }
        public DateTime? BirthDate { get; set; }
        public gender? Gender { get; set; }
        public DateTime? HiredDate { get; set; }
        public DateTime? ReleasedDate { get; set; }
        public TimeEntryUsedForPaychecksEnum? UseTimeEntry { get; set; }
        public IntuitAnyType? EmployeeEx { get; set; }
    }
    public class JobInfo
    {
        public JobStatusEnum? Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ProjectedEndDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public ReferenceType? JobTypeRef { get; set; }
    }
    public class JobType : IntuitEntity
    {
        public string? Name { get; set; }
        public ReferenceType? ParentRef { get; set; }
        public string? FullyQualifiedName { get; set; }
        public bool? Active { get; set; }
    }
    public class OtherName : NameBase
    {
        public string? AcctNum { get; set; }
        public PhysicalAddress? PrimaryAddr { get; set; }
        public PhysicalAddress[]? OtherAddr { get; set; }
        public IntuitAnyType? OtherNameEx { get; set; }
    }
    public class VendorType : IntuitEntity
    {
        public string? Name { get; set; }
        public ReferenceType? ParentRef { get; set; }
        public string? FullyQualifiedName { get; set; }
        public bool? Active { get; set; }
    }
    public class TaxAgency : Vendor
    {
        public ReferenceType? SalesTaxCodeRef { get; set; }
        public string? SalesTaxCountry { get; set; }
        public ReferenceType? SalesTaxReturnRef { get; set; }
        public string? TaxRegistrationNumber { get; set; }
        public string? ReportingPeriod { get; set; }
        public bool? TaxTrackedOnPurchases { get; set; }
        public ReferenceType? TaxOnPurchasesAccountRef { get; set; }
        public bool? TaxTrackedOnSales { get; set; }
        public ReferenceType? TaxTrackedOnSalesAccountRef { get; set; }
        public bool? TaxOnTax { get; set; }
        public DateTime? LastFileDate { get; set; }
        public IntuitAnyType? TaxAgencyExt { get; set; }
        public string? TaxAgencyConfig { get; set; }
    }
    public class VendorBankAccountDetail
    {
        public string? BankBranchIdentifier { get; set; }
        public string? BankAccountNumber { get; set; }
        public string? BankAccountName { get; set; }
        public string? StatementText { get; set; }
    }
    public class Warnings
    {
        public Warning[]? Warning { get; set; }
    }
    public class Warning
    {
        public string code { get; set; } = default!;
        public string? element { get; set; }
        public string Message { get; set; } = default!;
        public string? Detail { get; set; }
    }
    public class Error
    {
        public string code { get; set; } = default!;
        public string? element { get; set; }
        public string? Message { get; set; }
        public string? Detail { get; set; }
        public string? DetailLink { get; set; }
    }
    public class Fault
    {
        public string? type { get; set; }
        public Error[]? Error { get; set; }
    }
    public class IntuitResponse
    {
        public string? requestId { get; set; }
        public DateTimeOffset? time { get; set; }
        public string? status { get; set; }
        public Warnings? Warnings { get; set; }
        public RecurringTransaction? RecurringTransaction { get; set; }
        public Customer? Customer { get; set; }
        public CustomerType? CustomerType { get; set; }
        public Employee? Employee { get; set; }
        public Vendor? Vendor { get; set; }
        public OtherName? OtherName { get; set; }
        public Estimate? Estimate { get; set; }
        public SalesOrder? SalesOrder { get; set; }
        public SalesReceipt? SalesReceipt { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public Purchase? Purchase { get; set; }
        public BillPayment? BillPayment { get; set; }
        public Payment? Payment { get; set; }
        public CreditMemo? CreditMemo { get; set; }
        public StatementCharge? StatementCharge { get; set; }
        public ChargeCredit? ChargeCredit { get; set; }
        public CreditCardPaymentTxn? CreditCardPaymentTxn { get; set; }
        public ReimburseCharge? ReimburseCharge { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public Term? Term { get; set; }
        public JournalEntry? JournalEntry { get; set; }
        public Transfer? Transfer { get; set; }
        public Deposit? Deposit { get; set; }
        public Class? Class { get; set; }
        public TimeActivity? TimeActivity { get; set; }
        public Item? Item { get; set; }
        public TaxClassification? TaxClassification { get; set; }
        public TaxCode? TaxCode { get; set; }
        public TaxPayment? TaxPayment { get; set; }
        public TaxReturn? TaxReturn { get; set; }
        public TaxRate? TaxRate { get; set; }
        public VendorCredit? VendorCredit { get; set; }
        public SalesRep? SalesRep { get; set; }
        public InventorySite? InventorySite { get; set; }
        public QbTask? Task { get; set; }
        public UserAlert? UserAlert { get; set; }
        public VendorType? VendorType { get; set; }
        public PriceLevel? PriceLevel { get; set; }
        public Company? Company { get; set; }
        public CompanyInfo? CompanyInfo { get; set; }
        public FixedAsset? FixedAsset { get; set; }
        public RefundReceipt? RefundReceipt { get; set; }
        public Account? Account { get; set; }
        public Preferences? Preferences { get; set; }
        public Invoice? Invoice { get; set; }
        public EmailDeliveryInfo? EmailDeliveryInfo { get; set; }
        public Department? Department { get; set; }
        public Bill? Bill { get; set; }
        public Attachable? Attachable { get; set; }
        public BooleanTypeCustomFieldDefinition? BooleanTypeCustomFieldDefinition { get; set; }
        public CustomFieldDefinition? CustomFieldDefinition { get; set; }
        public DateTypeCustomFieldDefinition? DateTypeCustomFieldDefinition { get; set; }
        public NumberTypeCustomFieldDefinition? NumberTypeCustomFieldDefinition { get; set; }
        public StringTypeCustomFieldDefinition? StringTypeCustomFieldDefinition { get; set; }
        public Status? Status { get; set; }
        public SyncActivity? SyncActivity { get; set; }
        public Budget? Budget { get; set; }
        public TaxAgency? TaxAgency { get; set; }
        public TDSMetadata? TDSMetadata { get; set; }
        public CompanyCurrency? CompanyCurrency { get; set; }
        public ExchangeRate? ExchangeRate { get; set; }
        public JournalCode? JournalCode { get; set; }
        public QbdtEntityIdMapping? QbdtEntityIdMapping { get; set; }
        public MasterAccount? MasterAccount { get; set; }
        public Tag? Tag { get; set; }
        public TaxService? TaxService { get; set; }
        public IntuitEntity? IntuitObject { get => RecurringTransaction ?? Customer ?? CustomerType ?? Employee ?? Vendor ?? OtherName ?? Estimate ?? SalesOrder ?? SalesReceipt ?? PurchaseOrder ?? Purchase ?? BillPayment ?? Payment ?? CreditMemo ?? StatementCharge ?? ChargeCredit ?? CreditCardPaymentTxn ?? ReimburseCharge ?? PaymentMethod ?? Term ?? JournalEntry ?? Transfer ?? Deposit ?? Class ?? TimeActivity ?? Item ?? TaxClassification ?? TaxCode ?? TaxPayment ?? TaxReturn ?? TaxRate ?? VendorCredit ?? SalesRep ?? InventorySite ?? Task ?? UserAlert ?? VendorType ?? PriceLevel ?? Company ?? CompanyInfo ?? FixedAsset ?? RefundReceipt ?? Account ?? Preferences ?? Invoice ?? EmailDeliveryInfo ?? Department ?? Bill ?? Attachable ?? BooleanTypeCustomFieldDefinition ?? CustomFieldDefinition ?? DateTypeCustomFieldDefinition ?? NumberTypeCustomFieldDefinition ?? StringTypeCustomFieldDefinition ?? Status ?? SyncActivity ?? Budget ?? TaxAgency ?? TDSMetadata ?? CompanyCurrency ?? ExchangeRate ?? JournalCode ?? QbdtEntityIdMapping ?? MasterAccount ?? Tag ?? (IntuitEntity?)TaxService; }
        public Fault? Fault { get; set; }
        public Report? Report { get; set; }
        public QueryResponse? QueryResponse { get; set; }
        public BatchItemResponse[]? BatchItemResponse { get; set; }
        public CDCResponse[]? CDCResponse { get; set; }
        public AttachableResponse[]? AttachableResponse { get; set; }
        public SyncErrorResponse? SyncErrorResponse { get; set; }
        public OLBTransaction? OLBTransaction { get; set; }
        public OLBStatus? OLBStatus { get; set; }
    }
    public class QueryResponse
    {
        public int? startPosition { get; set; }
        public int? maxResults { get; set; }
        public int? totalCount { get; set; }
        public Warnings? Warnings { get; set; }
        public RecurringTransaction[]? RecurringTransaction { get; set; }
        public Customer[]? Customer { get; set; }
        public CustomerType[]? CustomerType { get; set; }
        public Employee[]? Employee { get; set; }
        public Vendor[]? Vendor { get; set; }
        public OtherName[]? OtherName { get; set; }
        public Estimate[]? Estimate { get; set; }
        public SalesOrder[]? SalesOrder { get; set; }
        public SalesReceipt[]? SalesReceipt { get; set; }
        public PurchaseOrder[]? PurchaseOrder { get; set; }
        public Purchase[]? Purchase { get; set; }
        public BillPayment[]? BillPayment { get; set; }
        public Payment[]? Payment { get; set; }
        public CreditMemo[]? CreditMemo { get; set; }
        public StatementCharge[]? StatementCharge { get; set; }
        public ChargeCredit[]? ChargeCredit { get; set; }
        public CreditCardPaymentTxn[]? CreditCardPaymentTxn { get; set; }
        public ReimburseCharge[]? ReimburseCharge { get; set; }
        public PaymentMethod[]? PaymentMethod { get; set; }
        public Term[]? Term { get; set; }
        public JournalEntry[]? JournalEntry { get; set; }
        public Transfer[]? Transfer { get; set; }
        public Deposit[]? Deposit { get; set; }
        public Class[]? Class { get; set; }
        public TimeActivity[]? TimeActivity { get; set; }
        public Item[]? Item { get; set; }
        public TaxClassification[]? TaxClassification { get; set; }
        public TaxCode[]? TaxCode { get; set; }
        public TaxPayment[]? TaxPayment { get; set; }
        public TaxReturn[]? TaxReturn { get; set; }
        public TaxRate[]? TaxRate { get; set; }
        public VendorCredit[]? VendorCredit { get; set; }
        public SalesRep[]? SalesRep { get; set; }
        public InventorySite[]? InventorySite { get; set; }
        public QbTask[]? Task { get; set; }
        public UserAlert[]? UserAlert { get; set; }
        public VendorType[]? VendorType { get; set; }
        public PriceLevel[]? PriceLevel { get; set; }
        public Company[]? Company { get; set; }
        public CompanyInfo[]? CompanyInfo { get; set; }
        public FixedAsset[]? FixedAsset { get; set; }
        public RefundReceipt[]? RefundReceipt { get; set; }
        public Account[]? Account { get; set; }
        public Preferences[]? Preferences { get; set; }
        public Invoice[]? Invoice { get; set; }
        public EmailDeliveryInfo[]? EmailDeliveryInfo { get; set; }
        public Department[]? Department { get; set; }
        public Bill[]? Bill { get; set; }
        public Attachable[]? Attachable { get; set; }
        public BooleanTypeCustomFieldDefinition[]? BooleanTypeCustomFieldDefinition { get; set; }
        public CustomFieldDefinition[]? CustomFieldDefinition { get; set; }
        public DateTypeCustomFieldDefinition[]? DateTypeCustomFieldDefinition { get; set; }
        public NumberTypeCustomFieldDefinition[]? NumberTypeCustomFieldDefinition { get; set; }
        public StringTypeCustomFieldDefinition[]? StringTypeCustomFieldDefinition { get; set; }
        public Status[]? Status { get; set; }
        public SyncActivity[]? SyncActivity { get; set; }
        public Budget[]? Budget { get; set; }
        public TaxAgency[]? TaxAgency { get; set; }
        public TDSMetadata[]? TDSMetadata { get; set; }
        public CompanyCurrency[]? CompanyCurrency { get; set; }
        public ExchangeRate[]? ExchangeRate { get; set; }
        public JournalCode[]? JournalCode { get; set; }
        public QbdtEntityIdMapping[]? QbdtEntityIdMapping { get; set; }
        public MasterAccount[]? MasterAccount { get; set; }
        public Tag[]? Tag { get; set; }
        public TaxService[]? TaxService { get; set; }
        public IntuitEntity[]? IntuitObjects { get => RecurringTransaction ?? Customer ?? CustomerType ?? Employee ?? Vendor ?? OtherName ?? Estimate ?? SalesOrder ?? SalesReceipt ?? PurchaseOrder ?? Purchase ?? BillPayment ?? Payment ?? CreditMemo ?? StatementCharge ?? ChargeCredit ?? CreditCardPaymentTxn ?? ReimburseCharge ?? PaymentMethod ?? Term ?? JournalEntry ?? Transfer ?? Deposit ?? Class ?? TimeActivity ?? Item ?? TaxClassification ?? TaxCode ?? TaxPayment ?? TaxReturn ?? TaxRate ?? VendorCredit ?? SalesRep ?? InventorySite ?? Task ?? UserAlert ?? VendorType ?? PriceLevel ?? Company ?? CompanyInfo ?? FixedAsset ?? RefundReceipt ?? Account ?? Preferences ?? Invoice ?? EmailDeliveryInfo ?? Department ?? Bill ?? Attachable ?? BooleanTypeCustomFieldDefinition ?? CustomFieldDefinition ?? DateTypeCustomFieldDefinition ?? NumberTypeCustomFieldDefinition ?? StringTypeCustomFieldDefinition ?? Status ?? SyncActivity ?? Budget ?? TaxAgency ?? TDSMetadata ?? CompanyCurrency ?? ExchangeRate ?? JournalCode ?? QbdtEntityIdMapping ?? MasterAccount ?? Tag ?? (IntuitEntity[]?)TaxService; }
        public Fault? Fault { get; set; }
    }
    public class CDCResponse
    {
        public int? size { get; set; }
        public QueryResponse[]? QueryResponse { get; set; }
        public Fault? Fault { get; set; }
    }
    public class BatchItemResponse
    {
        public string? bId { get; set; }
        public Warnings? Warnings { get; set; }
        public RecurringTransaction? RecurringTransaction { get; set; }
        public Customer? Customer { get; set; }
        public CustomerType? CustomerType { get; set; }
        public Employee? Employee { get; set; }
        public Vendor? Vendor { get; set; }
        public OtherName? OtherName { get; set; }
        public Estimate? Estimate { get; set; }
        public SalesOrder? SalesOrder { get; set; }
        public SalesReceipt? SalesReceipt { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public Purchase? Purchase { get; set; }
        public BillPayment? BillPayment { get; set; }
        public Payment? Payment { get; set; }
        public CreditMemo? CreditMemo { get; set; }
        public StatementCharge? StatementCharge { get; set; }
        public ChargeCredit? ChargeCredit { get; set; }
        public CreditCardPaymentTxn? CreditCardPaymentTxn { get; set; }
        public ReimburseCharge? ReimburseCharge { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public Term? Term { get; set; }
        public JournalEntry? JournalEntry { get; set; }
        public Transfer? Transfer { get; set; }
        public Deposit? Deposit { get; set; }
        public Class? Class { get; set; }
        public TimeActivity? TimeActivity { get; set; }
        public Item? Item { get; set; }
        public TaxClassification? TaxClassification { get; set; }
        public TaxCode? TaxCode { get; set; }
        public TaxPayment? TaxPayment { get; set; }
        public TaxReturn? TaxReturn { get; set; }
        public TaxRate? TaxRate { get; set; }
        public VendorCredit? VendorCredit { get; set; }
        public SalesRep? SalesRep { get; set; }
        public InventorySite? InventorySite { get; set; }
        public QbTask? Task { get; set; }
        public UserAlert? UserAlert { get; set; }
        public VendorType? VendorType { get; set; }
        public PriceLevel? PriceLevel { get; set; }
        public Company? Company { get; set; }
        public CompanyInfo? CompanyInfo { get; set; }
        public FixedAsset? FixedAsset { get; set; }
        public RefundReceipt? RefundReceipt { get; set; }
        public Account? Account { get; set; }
        public Preferences? Preferences { get; set; }
        public Invoice? Invoice { get; set; }
        public EmailDeliveryInfo? EmailDeliveryInfo { get; set; }
        public Department? Department { get; set; }
        public Bill? Bill { get; set; }
        public Attachable? Attachable { get; set; }
        public BooleanTypeCustomFieldDefinition? BooleanTypeCustomFieldDefinition { get; set; }
        public CustomFieldDefinition? CustomFieldDefinition { get; set; }
        public DateTypeCustomFieldDefinition? DateTypeCustomFieldDefinition { get; set; }
        public NumberTypeCustomFieldDefinition? NumberTypeCustomFieldDefinition { get; set; }
        public StringTypeCustomFieldDefinition? StringTypeCustomFieldDefinition { get; set; }
        public Status? Status { get; set; }
        public SyncActivity? SyncActivity { get; set; }
        public Budget? Budget { get; set; }
        public TaxAgency? TaxAgency { get; set; }
        public TDSMetadata? TDSMetadata { get; set; }
        public CompanyCurrency? CompanyCurrency { get; set; }
        public ExchangeRate? ExchangeRate { get; set; }
        public JournalCode? JournalCode { get; set; }
        public QbdtEntityIdMapping? QbdtEntityIdMapping { get; set; }
        public MasterAccount? MasterAccount { get; set; }
        public Tag? Tag { get; set; }
        public TaxService? TaxService { get; set; }
        public IntuitEntity? IntuitObject { get => RecurringTransaction ?? Customer ?? CustomerType ?? Employee ?? Vendor ?? OtherName ?? Estimate ?? SalesOrder ?? SalesReceipt ?? PurchaseOrder ?? Purchase ?? BillPayment ?? Payment ?? CreditMemo ?? StatementCharge ?? ChargeCredit ?? CreditCardPaymentTxn ?? ReimburseCharge ?? PaymentMethod ?? Term ?? JournalEntry ?? Transfer ?? Deposit ?? Class ?? TimeActivity ?? Item ?? TaxClassification ?? TaxCode ?? TaxPayment ?? TaxReturn ?? TaxRate ?? VendorCredit ?? SalesRep ?? InventorySite ?? Task ?? UserAlert ?? VendorType ?? PriceLevel ?? Company ?? CompanyInfo ?? FixedAsset ?? RefundReceipt ?? Account ?? Preferences ?? Invoice ?? EmailDeliveryInfo ?? Department ?? Bill ?? Attachable ?? BooleanTypeCustomFieldDefinition ?? CustomFieldDefinition ?? DateTypeCustomFieldDefinition ?? NumberTypeCustomFieldDefinition ?? StringTypeCustomFieldDefinition ?? Status ?? SyncActivity ?? Budget ?? TaxAgency ?? TDSMetadata ?? CompanyCurrency ?? ExchangeRate ?? JournalCode ?? QbdtEntityIdMapping ?? MasterAccount ?? Tag ?? (IntuitEntity?)TaxService; }
        public Fault? Fault { get; set; }
        public Report? Report { get; set; }
        public QueryResponse? QueryResponse { get; set; }
        public CDCResponse? CDCResponse { get; set; }
        public CascadeResponse? CascadeResponse { get; set; }
    }
    public class BatchItemRequest
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? bId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public OperationEnum? operation { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? optionsData { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RecurringTransaction? RecurringTransaction { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Customer? Customer { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomerType? CustomerType { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Employee? Employee { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Vendor? Vendor { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public OtherName? OtherName { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Estimate? Estimate { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SalesOrder? SalesOrder { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SalesReceipt? SalesReceipt { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PurchaseOrder? PurchaseOrder { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Purchase? Purchase { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BillPayment? BillPayment { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Payment? Payment { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CreditMemo? CreditMemo { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StatementCharge? StatementCharge { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ChargeCredit? ChargeCredit { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CreditCardPaymentTxn? CreditCardPaymentTxn { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ReimburseCharge? ReimburseCharge { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PaymentMethod? PaymentMethod { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Term? Term { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JournalEntry? JournalEntry { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Transfer? Transfer { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Deposit? Deposit { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Class? Class { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TimeActivity? TimeActivity { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Item? Item { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TaxClassification? TaxClassification { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TaxCode? TaxCode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TaxPayment? TaxPayment { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TaxReturn? TaxReturn { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TaxRate? TaxRate { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VendorCredit? VendorCredit { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SalesRep? SalesRep { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public InventorySite? InventorySite { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QbTask? Task { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UserAlert? UserAlert { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VendorType? VendorType { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PriceLevel? PriceLevel { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Company? Company { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CompanyInfo? CompanyInfo { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FixedAsset? FixedAsset { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RefundReceipt? RefundReceipt { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Account? Account { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Preferences? Preferences { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Invoice? Invoice { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public EmailDeliveryInfo? EmailDeliveryInfo { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Department? Department { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Bill? Bill { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Attachable? Attachable { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BooleanTypeCustomFieldDefinition? BooleanTypeCustomFieldDefinition { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CustomFieldDefinition? CustomFieldDefinition { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTypeCustomFieldDefinition? DateTypeCustomFieldDefinition { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NumberTypeCustomFieldDefinition? NumberTypeCustomFieldDefinition { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public StringTypeCustomFieldDefinition? StringTypeCustomFieldDefinition { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Status? Status { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public SyncActivity? SyncActivity { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Budget? Budget { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TaxAgency? TaxAgency { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TDSMetadata? TDSMetadata { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CompanyCurrency? CompanyCurrency { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ExchangeRate? ExchangeRate { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public JournalCode? JournalCode { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public QbdtEntityIdMapping? QbdtEntityIdMapping { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public MasterAccount? MasterAccount { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Tag? Tag { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public TaxService? TaxService { get; set; }
        [JsonIgnore]
        public IntuitEntity? IntuitObject { get => RecurringTransaction ?? Customer ?? CustomerType ?? Employee ?? Vendor ?? OtherName ?? Estimate ?? SalesOrder ?? SalesReceipt ?? PurchaseOrder ?? Purchase ?? BillPayment ?? Payment ?? CreditMemo ?? StatementCharge ?? ChargeCredit ?? CreditCardPaymentTxn ?? ReimburseCharge ?? PaymentMethod ?? Term ?? JournalEntry ?? Transfer ?? Deposit ?? Class ?? TimeActivity ?? Item ?? TaxClassification ?? TaxCode ?? TaxPayment ?? TaxReturn ?? TaxRate ?? VendorCredit ?? SalesRep ?? InventorySite ?? Task ?? UserAlert ?? VendorType ?? PriceLevel ?? Company ?? CompanyInfo ?? FixedAsset ?? RefundReceipt ?? Account ?? Preferences ?? Invoice ?? EmailDeliveryInfo ?? Department ?? Bill ?? Attachable ?? BooleanTypeCustomFieldDefinition ?? CustomFieldDefinition ?? DateTypeCustomFieldDefinition ?? NumberTypeCustomFieldDefinition ?? StringTypeCustomFieldDefinition ?? Status ?? SyncActivity ?? Budget ?? TaxAgency ?? TDSMetadata ?? CompanyCurrency ?? ExchangeRate ?? JournalCode ?? QbdtEntityIdMapping ?? MasterAccount ?? Tag ?? (IntuitEntity?)TaxService; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Query { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ReportQuery { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CDCQuery? CDCQuery { get; set; }
    }
    public class CDCQuery
    {
        public string? Entities { get; set; }
        public DateTimeOffset? ChangedSince { get; set; }
    }
    public class IntuitBatchRequest
    {
        public BatchItemRequest[] BatchItemRequest { get; set; } = default!;
    }
    public class AttachableResponse
    {
        public Attachable? Attachable { get; set; }
        public Fault? Fault { get; set; }
    }
    public class RecurringTransaction : IntuitEntity
    {
        public Customer? Customer { get; set; }
        public CustomerType? CustomerType { get; set; }
        public Employee? Employee { get; set; }
        public Vendor? Vendor { get; set; }
        public OtherName? OtherName { get; set; }
        public Estimate? Estimate { get; set; }
        public SalesOrder? SalesOrder { get; set; }
        public SalesReceipt? SalesReceipt { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public Purchase? Purchase { get; set; }
        public BillPayment? BillPayment { get; set; }
        public Payment? Payment { get; set; }
        public CreditMemo? CreditMemo { get; set; }
        public StatementCharge? StatementCharge { get; set; }
        public ChargeCredit? ChargeCredit { get; set; }
        public CreditCardPaymentTxn? CreditCardPaymentTxn { get; set; }
        public ReimburseCharge? ReimburseCharge { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public Term? Term { get; set; }
        public JournalEntry? JournalEntry { get; set; }
        public Transfer? Transfer { get; set; }
        public Deposit? Deposit { get; set; }
        public Class? Class { get; set; }
        public TimeActivity? TimeActivity { get; set; }
        public Item? Item { get; set; }
        public TaxClassification? TaxClassification { get; set; }
        public TaxCode? TaxCode { get; set; }
        public TaxPayment? TaxPayment { get; set; }
        public TaxReturn? TaxReturn { get; set; }
        public TaxRate? TaxRate { get; set; }
        public VendorCredit? VendorCredit { get; set; }
        public SalesRep? SalesRep { get; set; }
        public InventorySite? InventorySite { get; set; }
        public QbTask? Task { get; set; }
        public UserAlert? UserAlert { get; set; }
        public VendorType? VendorType { get; set; }
        public PriceLevel? PriceLevel { get; set; }
        public Company? Company { get; set; }
        public CompanyInfo? CompanyInfo { get; set; }
        public FixedAsset? FixedAsset { get; set; }
        public RefundReceipt? RefundReceipt { get; set; }
        public Account? Account { get; set; }
        public Preferences? Preferences { get; set; }
        public Invoice? Invoice { get; set; }
        public EmailDeliveryInfo? EmailDeliveryInfo { get; set; }
        public Department? Department { get; set; }
        public Bill? Bill { get; set; }
        public Attachable? Attachable { get; set; }
        public BooleanTypeCustomFieldDefinition? BooleanTypeCustomFieldDefinition { get; set; }
        public CustomFieldDefinition? CustomFieldDefinition { get; set; }
        public DateTypeCustomFieldDefinition? DateTypeCustomFieldDefinition { get; set; }
        public NumberTypeCustomFieldDefinition? NumberTypeCustomFieldDefinition { get; set; }
        public StringTypeCustomFieldDefinition? StringTypeCustomFieldDefinition { get; set; }
        public Status? Status { get; set; }
        public SyncActivity? SyncActivity { get; set; }
        public Budget? Budget { get; set; }
        public TaxAgency? TaxAgency { get; set; }
        public TDSMetadata? TDSMetadata { get; set; }
        public CompanyCurrency? CompanyCurrency { get; set; }
        public ExchangeRate? ExchangeRate { get; set; }
        public JournalCode? JournalCode { get; set; }
        public QbdtEntityIdMapping? QbdtEntityIdMapping { get; set; }
        public MasterAccount? MasterAccount { get; set; }
        public Tag? Tag { get; set; }
        public TaxService? TaxService { get; set; }
        public IntuitEntity IntuitObject { get => Customer ?? CustomerType ?? Employee ?? Vendor ?? OtherName ?? Estimate ?? SalesOrder ?? SalesReceipt ?? PurchaseOrder ?? Purchase ?? BillPayment ?? Payment ?? CreditMemo ?? StatementCharge ?? ChargeCredit ?? CreditCardPaymentTxn ?? ReimburseCharge ?? PaymentMethod ?? Term ?? JournalEntry ?? Transfer ?? Deposit ?? Class ?? TimeActivity ?? Item ?? TaxClassification ?? TaxCode ?? TaxPayment ?? TaxReturn ?? TaxRate ?? VendorCredit ?? SalesRep ?? InventorySite ?? Task ?? UserAlert ?? VendorType ?? PriceLevel ?? Company ?? CompanyInfo ?? FixedAsset ?? RefundReceipt ?? Account ?? Preferences ?? Invoice ?? EmailDeliveryInfo ?? Department ?? Bill ?? Attachable ?? BooleanTypeCustomFieldDefinition ?? CustomFieldDefinition ?? DateTypeCustomFieldDefinition ?? NumberTypeCustomFieldDefinition ?? StringTypeCustomFieldDefinition ?? Status ?? SyncActivity ?? Budget ?? TaxAgency ?? TDSMetadata ?? CompanyCurrency ?? ExchangeRate ?? JournalCode ?? QbdtEntityIdMapping ?? MasterAccount ?? Tag ?? (IntuitEntity)TaxService!; }
    }
    public class Status : IntuitEntity
    {
        public string? RequestId { get; set; }
        public string? BatchId { get; set; }
        public string ObjectType { get; set; } = default!;
        public string? StateCode { get; set; }
        public string? StateDesc { get; set; }
        public string? MessageCode { get; set; }
        public string? MessageDesc { get; set; }
    }
    public class SyncActivity : IntuitEntity
    {
        public DateTimeOffset? LatestUploadDateTime { get; set; }
        public DateTimeOffset? LatestWriteBackDateTime { get; set; }
        public SyncType? SyncType { get; set; }
        public DateTimeOffset? StartSyncTMS { get; set; }
        public DateTimeOffset? EndSyncTMS { get; set; }
        public string? EntityName { get; set; }
        public int? EntityRowCount { get; set; }
    }
    public class SyncErrorResponse
    {
        public DateTimeOffset? latestUploadTime { get; set; }
        public int? startPosition { get; set; }
        public int? maxResults { get; set; }
        public int? totalCount { get; set; }
        public SyncError[]? SyncError { get; set; }
    }
    public class SyncError
    {
        public string? Type { get; set; }
        public string? AppToken { get; set; }
        public Error? Error { get; set; }
        public SyncObject? CloudVersion { get; set; }
        public SyncObject? QBVersion { get; set; }
    }
    public class SyncObject
    {
        public RecurringTransaction? RecurringTransaction { get; set; }
        public Customer? Customer { get; set; }
        public CustomerType? CustomerType { get; set; }
        public Employee? Employee { get; set; }
        public Vendor? Vendor { get; set; }
        public OtherName? OtherName { get; set; }
        public Estimate? Estimate { get; set; }
        public SalesOrder? SalesOrder { get; set; }
        public SalesReceipt? SalesReceipt { get; set; }
        public PurchaseOrder? PurchaseOrder { get; set; }
        public Purchase? Purchase { get; set; }
        public BillPayment? BillPayment { get; set; }
        public Payment? Payment { get; set; }
        public CreditMemo? CreditMemo { get; set; }
        public StatementCharge? StatementCharge { get; set; }
        public ChargeCredit? ChargeCredit { get; set; }
        public CreditCardPaymentTxn? CreditCardPaymentTxn { get; set; }
        public ReimburseCharge? ReimburseCharge { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        public Term? Term { get; set; }
        public JournalEntry? JournalEntry { get; set; }
        public Transfer? Transfer { get; set; }
        public Deposit? Deposit { get; set; }
        public Class? Class { get; set; }
        public TimeActivity? TimeActivity { get; set; }
        public Item? Item { get; set; }
        public TaxClassification? TaxClassification { get; set; }
        public TaxCode? TaxCode { get; set; }
        public TaxPayment? TaxPayment { get; set; }
        public TaxReturn? TaxReturn { get; set; }
        public TaxRate? TaxRate { get; set; }
        public VendorCredit? VendorCredit { get; set; }
        public SalesRep? SalesRep { get; set; }
        public InventorySite? InventorySite { get; set; }
        public QbTask? Task { get; set; }
        public UserAlert? UserAlert { get; set; }
        public VendorType? VendorType { get; set; }
        public PriceLevel? PriceLevel { get; set; }
        public Company? Company { get; set; }
        public CompanyInfo? CompanyInfo { get; set; }
        public FixedAsset? FixedAsset { get; set; }
        public RefundReceipt? RefundReceipt { get; set; }
        public Account? Account { get; set; }
        public Preferences? Preferences { get; set; }
        public Invoice? Invoice { get; set; }
        public EmailDeliveryInfo? EmailDeliveryInfo { get; set; }
        public Department? Department { get; set; }
        public Bill? Bill { get; set; }
        public Attachable? Attachable { get; set; }
        public BooleanTypeCustomFieldDefinition? BooleanTypeCustomFieldDefinition { get; set; }
        public CustomFieldDefinition? CustomFieldDefinition { get; set; }
        public DateTypeCustomFieldDefinition? DateTypeCustomFieldDefinition { get; set; }
        public NumberTypeCustomFieldDefinition? NumberTypeCustomFieldDefinition { get; set; }
        public StringTypeCustomFieldDefinition? StringTypeCustomFieldDefinition { get; set; }
        public Status? Status { get; set; }
        public SyncActivity? SyncActivity { get; set; }
        public Budget? Budget { get; set; }
        public TaxAgency? TaxAgency { get; set; }
        public TDSMetadata? TDSMetadata { get; set; }
        public CompanyCurrency? CompanyCurrency { get; set; }
        public ExchangeRate? ExchangeRate { get; set; }
        public JournalCode? JournalCode { get; set; }
        public QbdtEntityIdMapping? QbdtEntityIdMapping { get; set; }
        public MasterAccount? MasterAccount { get; set; }
        public Tag? Tag { get; set; }
        public TaxService? TaxService { get; set; }
        public IntuitEntity? IntuitObject { get => RecurringTransaction ?? Customer ?? CustomerType ?? Employee ?? Vendor ?? OtherName ?? Estimate ?? SalesOrder ?? SalesReceipt ?? PurchaseOrder ?? Purchase ?? BillPayment ?? Payment ?? CreditMemo ?? StatementCharge ?? ChargeCredit ?? CreditCardPaymentTxn ?? ReimburseCharge ?? PaymentMethod ?? Term ?? JournalEntry ?? Transfer ?? Deposit ?? Class ?? TimeActivity ?? Item ?? TaxClassification ?? TaxCode ?? TaxPayment ?? TaxReturn ?? TaxRate ?? VendorCredit ?? SalesRep ?? InventorySite ?? Task ?? UserAlert ?? VendorType ?? PriceLevel ?? Company ?? CompanyInfo ?? FixedAsset ?? RefundReceipt ?? Account ?? Preferences ?? Invoice ?? EmailDeliveryInfo ?? Department ?? Bill ?? Attachable ?? BooleanTypeCustomFieldDefinition ?? CustomFieldDefinition ?? DateTypeCustomFieldDefinition ?? NumberTypeCustomFieldDefinition ?? StringTypeCustomFieldDefinition ?? Status ?? SyncActivity ?? Budget ?? TaxAgency ?? TDSMetadata ?? CompanyCurrency ?? ExchangeRate ?? JournalCode ?? QbdtEntityIdMapping ?? MasterAccount ?? Tag ?? (IntuitEntity?)TaxService; }
        public Fault? Fault { get; set; }
    }
    public class Cascade
    {
        public string EntityName { get; set; } = default!;
        public string Id { get; set; } = default!;
        public NameValue[]? KeyValue { get; set; }
    }
    public class CascadeResponse
    {
        public Cascade[]? Cascade { get; set; }
    }
    public class Attributes
    {
        public Attribute[]? Attribute { get; set; }
    }
    public class Attribute
    {
        public string Type { get; set; } = default!;
        public string Value { get; set; } = default!;
    }
    public class Columns
    {
        public Column[]? Column { get; set; }
    }
    public class Column
    {
        public string ColTitle { get; set; } = default!;
        public string ColType { get; set; } = default!;
        public NameValue[]? MetaData { get; set; }
        public Columns? Columns { get; set; }
    }
    public class ColData
    {
        public string? value { get; set; }
        public string? id { get; set; }
        public string? href { get; set; }
        public Attributes? Attributes { get; set; }
    }
    public class Row
    {
        public RowTypeEnum type { get; set; } = default!;
        public string? group { get; set; }
        public string? id { get; set; }
        public string? parentId { get; set; }
        public Header? Header { get; set; }
        public Rows? Rows { get; set; }
        public Summary? Summary { get; set; }
        public ColData[]? ColData { get; set; }
    }
    public class Header
    {
        public ColData[] ColData { get; set; } = default!;
    }
    public class Summary
    {
        public ColData[] ColData { get; set; } = default!;
    }
    public class Rows
    {
        public Row[]? Row { get; set; }
    }
    public class ReportHeader
    {
        public DateTimeOffset? Time { get; set; }
        public string? ReportName { get; set; }
        public string? DateMacro { get; set; }
        public ReportBasisEnum? ReportBasis { get; set; }
        public string? StartPeriod { get; set; }
        public string? EndPeriod { get; set; }
        public string? SummarizeColumnsBy { get; set; }
        public string? Currency { get; set; }
        public string? Customer { get; set; }
        public string? Vendor { get; set; }
        public string? Employee { get; set; }
        public string? Item { get; set; }
        public string? Class { get; set; }
        public string? Department { get; set; }
        public NameValue[]? Option { get; set; }
    }
    public class Report
    {
        public ReportHeader? Header { get; set; }
        public Columns? Columns { get; set; }
        public Rows? Rows { get; set; }
    }
    public class TaxRateDetails
    {
        public string? TaxRateName { get; set; }
        public string? TaxRateId { get; set; }
        public decimal? RateValue { get; set; }
        public string? TaxAgencyId { get; set; }
        public TaxRateApplicableOnEnum? TaxApplicableOn { get; set; }
    }
    public class TaxService : IntuitEntity
    {
        public string? TaxCode { get; set; }
        public string? TaxCodeId { get; set; }
        public TaxRateDetails[]? TaxRateDetails { get; set; }
        public Fault? Fault { get; set; }
    }
}
