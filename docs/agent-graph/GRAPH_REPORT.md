# Graph Report - XPoster  (2026-06-25)

## Summary
- 1103 nodes · 1858 edges · 141 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Models` - 2 edges
2. `XPoster.Tests.Models` - 2 edges
3. `XPoster.Tests.Models` - 2 edges
4. `PostMissingBranchTests` - 2 edges
5. `XPoster.Tests.Models` - 2 edges
6. `XPoster.Tests.Services` - 2 edges
7. `DeepSeekOptionsTests` - 2 edges
8. `AzureFoundryOptionsValidatorTests` - 2 edges
9. `XPoster.Services` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_FalAi_EmptyImagesArray_ReturnsEmptyArray(), ParseImageResponseAsync_FalAi_DownloadFails_ReturnsEmptyArray(), ParseImageResponseAsync_AzureFoundry_ValidB64Json_ReturnsDecodedBytes(), ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, XPoster.Tests.Services, ChatCompletionJson(), GenerateImageAsync_WhenApiReturns200_ReturnsDecodedBytes(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, AiServiceHelperImageTests, Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_NullAllowedOrigin_SkipsOriginCheckAndDownloads(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, SectionName_IsDeepSeek(), PerplexityOptionsExtensionsTests, SectionName_IsAzureFoundry(), register(), AzureFoundryOptionsExtensionsTests, AddPerplexityOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock() (+15 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WithImage_TriesUploadAndReturnsFalse(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhitespaceContent_ReturnsFalse(), BuildSenderWithFactory(), Constructor_InitializesCorrectly() (+13 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (20): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsEmpty(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsWhitespace(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallTagReplacementProvider_ExactlyOnce_WhenOrchestrationSucceeds(), OrchestrateAsync_Should_ReturnNull_When_FeedUrlProviderReturnsEmptyList(), OrchestrateAsync_Should_ReturnNull_When_NoFeedsFound() (+12 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_DoesNotCallAnyOutboundSocialApi(), DryRunSenderTests(), new(), MessageMaxLenght_ReturnsIntMaxValue(), SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WhenProbeKeyMissing_LogsError() (+12 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), XPoster.Tests.Services, MakeHandlerMock(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning() (+11 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, DeepSeekService(), BuildService(), ChatCompletionJson(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, SendAsync(), XPoster.Tests.Services, BuildRssXml(), BuildFactory(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), foreach() (+10 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_RequestBodyContainsModelField(), AzureFoundryService(), if() (+9 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.13
Nodes (15): OrchestratorFactoryTests.cs, Resolve_Should_ResolveXSender_WhenProfileUsesX(), XPoster.Tests.Orchestrators, Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), OrchestratorFactory(), Resolve_Should_NotRequestTextProvider_WhenProfileHasNoTextProvider(), Resolve_Should_RequestImageProviderKey_WhenProfileSpecifiesImageProvider() (+7 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_Firm_ContainsExpectedHashtags(), OpenAIImageResponse_CanBeCreated_WithData(), OpenAIResponse_CanBeCreated_WithChoices(), Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), RSSFeed_PublishDate_DefaultsToMinValue() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed() (+6 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GenerateImageAsync(), catch(), while(), GetSummary(), OpenAiService(), if() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingTextPlaceholder_Fails() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests, XPoster.Tests.Services, GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), BuildProvider(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_MissingModelId_Fails(), Validate_MissingApiKey_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), FalAiOptionsValidatorTests, Validate_ModelIdWithUnsafeCharacters_Fails() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), XPoster.Tests.SenderPlugins, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse() (+5 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, DeepSeekService(), BuildSummaryPayload(), BuildImagePromptPayload(), GetSummaryAsync(), XPoster.Services, while() (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, var(), while(), XPoster.Services, if(), BuildImagePromptPayload(), GetSummaryAsync() (+4 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithoutImage(), XPoster.Tests.SenderPlugins, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), new() (+4 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), BuildService(), FalAiImageServiceTests, FalImageJson(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_Returns429_LogsWarning() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), ConfigurationTagReplacementProvider(), ConfigurationTagReplacementProviderTests, GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), Constructor_Should_Throw_When_OptionsIsNull() (+4 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.18
Nodes (11): OrchestratorFactoryTests.cs, Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider(), OrchestratorFactoryTests(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), CreateFactory(), CreateFactoryWithProfiles(), Resolve_Should_RequestTextProviderKey_WhenProfileSpecifiesTextProvider() (+3 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, MakeHandlerMock(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), FalAiImageService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+3 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, BuildSender(), SendAsync_NullPost_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), XPoster.Tests.SenderPlugins (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationFeedUrlProvider(), ConfigurationFeedUrlProviderTests, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty() (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), new(), OrchestrateAsync_Should_ReturnNull_And_DisableSendIt_When_ProviderReturnsEmptyList(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url() (+3 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.35
Nodes (11): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests, FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), PowerLawSlot_Should_HaveNullTextAndImageProvider(), GetProfiles_Should_HaveUniqueHours(), GetProfiles_Should_NotContainDryRunSlot() (+3 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, BuildSender(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), InSenderResilienceTests, SendAsync_WhenLinkedInReturns200_ReturnsTrue() (+3 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), XSender_ImplementsISender(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_InitializesCorrectly() (+2 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.38
Nodes (10): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), ScheduledOrchestrationProfileTests, XPoster.Tests.Abstraction, Constructor_Should_SetAllFields_WhenBothProvidersSupplied() (+2 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), XPoster.Tests.Orchestrators, SendIt_Set_ThrowsNotImplementedException(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsNull(), NoOrchestratorTests() (+2 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptionsTests, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, MakeService(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildDelayedHandler(), BuildSequenceHandler(), XPoster.Tests.Integration, HttpResponseMessage(), params(), var() (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptionsTests (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanSetPublishDate(), XPoster.Tests.Models, RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.22
Nodes (9): InSender.cs, catch(), XPoster.SenderPlugins, using(), generatePayLoad(), ResolveAuthorUrn(), InvalidOperationException(), Exception() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis() (+1 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_DescriptionMatchesEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, AiProviderExtensionsTests

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests

### Community 49 - "Entity (Community 49)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), PostMissingBranchTests

### Community 47 - "Entity (Community 47)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GenerateImageAsync(), GetChatCompletionsEndpoint(), GetSummaryAsync(), GetImagePromptAsync(), XPoster.Services, BuildSummaryPayload(), AzureFoundryService()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), XPoster.Tests.Integration, CreateLogger(), Dispose(), IsEnabled(), CaptureLogger()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, XPoster.Models, Choice, Message, OpenAIImageResponse, ImageData, OpenAIResponse

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Contracts, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), XFunctionMissingBranchTests(), XPoster.Tests, Run_Should_Rethrow_When_Factory_Throws()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Orchestrators, typeof(), GetProfiles(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, FalAiImageService(), if(), catch(), GenerateImageAsync(), XPoster.Services

### Community 51 - "Entity (Community 51)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, var(), catch(), if(), GetImageGenerationEndpoint(), BuildImagePromptPayload(), while()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ParseImageResponseAsync(), XPoster.Services, ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), ExtractOpenAiBytes(), LogAndReturnEmpty()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, BuildCreds(), Constructor_InitializesCorrectly(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, Uri(), if(), DryRunSlotProfileProvider(), DefaultAzureCredential()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, GetSummaryAsync(), GetImagePromptAsync(), ITextToTextProvider

### Community 60 - "Entity (Community 60)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, IsTransientHttpFailure(), AddResilientHttpClient(), XPoster.Extensions, AddHttpClients()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), foreach(), Validate(), XPoster.Models

### Community 70 - "Entity (Community 70)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, JsonResponse(), HttpClient(), MakeNoOpClient(), var(), MakeDownloadClient()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XFunctionTests(), XPoster.Tests, Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSender(), InSenderTests(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, DryRunSender(), SendAsync(), if(), XPoster.SenderPlugins

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 64 - "Entity (Community 64)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, StringContent()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.33
Nodes (6): FeedOrchestrator.cs, GenerateSummaryAsync(), XPoster.Orchestrators, catch(), ApplyTagReplacements(), AcquireFeedContentAsync()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), XPoster.Contracts, ITagReplacementProvider

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), XPoster.Services, GetFeedsAsync(), catch()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.40
Nodes (5): IgSender.cs, UploadImageToPublicUrl(), catch(), SendAsync(), XPoster.SenderPlugins

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, GetFeedUrls(), IFeedUrlProvider

### Community 89 - "Entity (Community 89)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, XPoster.Orchestrators, return(), Resolve(), foreach()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Services

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), IOrchestrator, XPoster.Contracts

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Contracts

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, ConfigurationFeedUrlProvider(), GetFeedUrls()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), ITimeProvider, XPoster.Contracts

### Community 73 - "Entity (Community 73)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, IOrchestratorFactory, Resolve()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), XPoster.Orchestrators, GetReplacements()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), OrchestratorFactory(), CreateOrchestratorInstance()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, catch(), Run()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 106 - "Entity (Community 106)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 108 - "Entity (Community 108)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 109 - "Entity (Community 109)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 100 - "Entity (Community 100)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, if(), FeedOrchestrator(), foreach()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 91 - "Entity (Community 91)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), BuildSequenceHandler()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 111 - "Entity (Community 111)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Orchestrators

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 132 - "Entity (Community 132)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 124 - "Entity (Community 124)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, XPoster.Credentials, IgCredentials.cs

### Community 127 - "Entity (Community 127)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 129 - "Entity (Community 129)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 122 - "Entity (Community 122)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FeedOptions.cs, FeedOptions.cs

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 120 - "Entity (Community 120)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Contracts

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 118 - "Entity (Community 118)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 140 - "Entity (Community 140)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

