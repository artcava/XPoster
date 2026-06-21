# Graph Report - XPoster  (2026-06-21)

## Summary
- 1073 nodes · 1807 edges · 141 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.Orchestrators` - 2 edges
2. `OpenAiOptionsValidatorTests` - 2 edges
3. `XPoster.Tests.Services` - 2 edges
4. `XPoster.Tests.SenderPlugins` - 2 edges
5. `XPoster.Contracts` - 2 edges
6. `XPoster.Orchestrators` - 2 edges
7. `XPoster.Tests.Helpers` - 2 edges
8. `XPoster.Contracts` - 2 edges
9. `XPoster` - 2 edges
10. `XPoster.Tests` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, OpenAiB64Json(), new(), FalAiJson(), ChatJson(), AiServiceHelperTests, ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray(), OpenAiService(), MakeHandlerMock(), MakeHandler() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.07
Nodes (30): AiServiceHelperImageTests.cs, Parse_AzureFoundry_ValidB64_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty() (+22 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), BuildProvider(), AzureFoundryOptionsExtensionsTests, BuildConfig(), AddPerplexityOptions_RegistersValidator() (+21 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.15
Nodes (26): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), PerplexityService(), MakeSequentialHandlerMock(), MakeHandlerMock(), PerplexityServiceTests, XPoster.Tests.Services (+18 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), XPoster.Tests.Services, MakeHandlerMock(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString() (+13 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithImage_TriesUploadAndReturnsFalse(), SendAsync_WhenInstagramApiReturns429_ReturnsFalse(), SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse() (+13 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, ValidPost(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildConfig(), BuildSender() (+12 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), BuildService(), GenerateImageAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_RequestBodyContainsModelField(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint() (+9 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.27
Nodes (14): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_Should_ApplyHashtagsCorrectly(), CreateOrchestrator(), new(), FeedOrchestratorTests(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull() (+6 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, XPoster.Tests.Models, Post_CanHold_ImageBytes(), RSSFeed_PublishDate_DefaultsToMinValue(), Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties(), OpenAIResponse_CanBeCreated_WithChoices() (+6 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WithValidOptions_ReturnsSuccess() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), OpenAiOptionsValidatorTests, Validate_MissingSummaryPlaceholder_Fails(), Validate_DefaultOptions_Succeeds(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_MissingApiKey_Fails(), Validate_MissingModelId_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_ModelIdWithUnsafeCharacters_Fails() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetSummaryAsync(), GenerateImageAsync(), GetSummary(), GetImagePromptAsync(), GetPromptForImage(), catch() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), BuildSender(), InSenderMissingBranchTests() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, new(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), PostWithImage(), PostWithoutImage(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi() (+4 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), XPoster.Tests.Services, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray() (+4 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), BuildSender(), SendAsync_NullPost_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), MessageMaxLenght_Returns250(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse() (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, FalAiImageService(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray() (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, DeepSeekService(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), BuildHybrid(), ChatCompletionJson(), FalAiImageService(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), XPoster.Tests.Services (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Orchestrators, new(), OrchestrateAsync_Should_ReturnNull_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url() (+3 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), XPoster.Tests.Orchestrators, Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationFeedUrlProviderTests, GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSender(), BuildSender(), ValidPost(), InSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue() (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XSenderTests(), XPoster.Tests.SenderPlugins, XSender_ImplementsISender() (+2 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), Resolve_Should_ResolveInSender_WhenProfileUsesInSummaryFeed(), Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider(), OrchestratorFactory(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRunSend(), XPoster.Tests.Orchestrators (+2 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Orchestrators, NoOrchestratorTests(), SendIt_Set_ThrowsNotImplementedException(), OrchestrateAsync_ReturnsNull(), ProduceImage_IsAlwaysFalse(), ProduceImage_Set_ThrowsNotImplementedException() (+2 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), PowerLawOrchestratorTests(), XPoster.Tests.Orchestrators, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptionsTests, XPoster.Tests.Models (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, XPoster.Tests.Models, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse() (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, HttpResponseMessage(), BuildSequenceHandler(), BuildDelayedHandler(), BuildProviderWithHandler(), var(), XPoster.Tests.Integration (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.22
Nodes (9): InSender.cs, ResolveAuthorUrn(), InvalidOperationException(), catch(), Exception(), generatePayLoad(), using(), XPoster.SenderPlugins (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLoggerProvider(), CaptureLogger(), IsEnabled(), XPoster.Tests.Integration, CreateLogger(), Dispose()

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), InSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), FeedServiceTests(), GetFeedsAsync_FiltersByKeyword_AndDate(), XPoster.Tests.Services, GetFeedsAsync_SetsCache_WhenFeedsFetched()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, XPoster.Services, GetImagePromptAsync(), BuildSummaryPayload(), AzureFoundryService(), GetSummaryAsync(), GetChatCompletionsEndpoint(), GenerateImageAsync()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, InvalidOperationException(), XPoster.Orchestrators, GetByProvider(), ArgumentException(), AiServiceFactory(), if()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), PostMissingBranchTests

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, XPoster.Tests.Orchestrators, GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Choice, ImageData, Message, OpenAIResponse, OpenAIImageResponse, XPoster.Models

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_MissingPlaceholders_Fails(), Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.25
Nodes (8): PerplexityService.cs, while(), if(), GetImagePromptAsync(), GenerateImageAsync(), GetSummaryAsync(), nameof(), XPoster.Services

### Community 56 - "Entity (Community 56)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync(), ParseImageResponseAsync(), XPoster.Services, ExtractOpenAiBytes(), LogAndReturnEmpty()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_Rethrow_When_Factory_Throws(), XFunctionMissingBranchTests(), XPoster.Tests, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), Run_Should_LogError_When_PostAsync_ReturnsFalse()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, CreateFactory(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), OrchestratorFactoryTests(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactoryWithProfiles(), SetupMocksForOrchestratorFactory()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, XPoster.Services, FalAiImageService(), GenerateImageAsync(), catch(), if()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.52
Nodes (7): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, XPoster.Contracts, GetImagePromptAsync(), GenerateImageAsync(), IAiService, GetSummaryAsync()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, catch(), GetImageGenerationEndpoint(), var(), if(), while(), BuildImagePromptPayload()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, InSender_ImplementsISender(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildCreds(), Constructor_InitializesCorrectly(), XPoster.Tests.SenderPlugins

### Community 53 - "Entity (Community 53)"
Cohesion: 0.29
Nodes (7): DeepSeekService.cs, while(), XPoster.Services, if(), BuildSummaryPayload(), GenerateImageAsync(), GetSummaryAsync()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), XPoster.Tests.Contracts, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, HybridAiService(), GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync(), XPoster.Services

### Community 74 - "Entity (Community 74)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, InSender(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSenderTests()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), foreach(), XPoster.Models, Validate()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddResilientHttpClient(), IsTransientHttpFailure(), AddHttpClients(), XPoster.Extensions

### Community 71 - "Entity (Community 71)"
Cohesion: 0.33
Nodes (6): PerplexityService.cs, PerplexityService(), var(), BuildSummaryPayload(), BuildImagePromptPayload(), GetChatCompletionsEndpoint()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, Uri(), DryRunSlotProfileProvider(), if(), DefaultAzureCredential()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): DeepSeekService.cs, var(), DeepSeekService(), BuildImagePromptPayload(), GetImagePromptAsync(), GetChatCompletionsEndpoint()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), ScheduledOrchestrationProfile(), XPoster.Orchestrators, DryRunSlotProfileProvider()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), if(), DryRunSender()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, Constructor_NullFalAiService_ThrowsArgumentNullException(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), HybridAiService(), BuildDeepSeekService(), BuildFalService()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, return(), XPoster.Orchestrators, foreach(), Resolve(), ResolveAiProvider()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), StringContent(), XPoster.Tests.Integration, Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeDownloadClient(), MakeNoOpClient(), var(), HttpClient(), JsonResponse()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XFunctionTests(), XPoster.Tests, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 91 - "Entity (Community 91)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, catch(), ReplaceEveryFirstOccurenceOf(), GenerateMessage(), XPoster.Orchestrators

### Community 78 - "Entity (Community 78)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), UploadImageToPublicUrl(), XPoster.SenderPlugins, catch()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, if(), PowerLawOrchestrator()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, IFeedUrlProvider, GetFeedUrls()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, GetCryptoValue(), ICryptoService

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), IAiServiceFactory, XPoster.Contracts

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Contracts, ITimeProvider

### Community 85 - "Entity (Community 85)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, catch()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, TimeProvider, GetCurrentTime()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Services, LocalOverrideTimeProvider()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, ConfigurationFeedUrlProvider(), GetFeedUrls()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), ISlotProfileProvider, XPoster.Contracts

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), return(), if()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), BuildSequenceHandler()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): XFunction.cs, catch(), XPoster, Run()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 106 - "Entity (Community 106)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Abstraction

### Community 108 - "Entity (Community 108)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 103 - "Entity (Community 103)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), CreateOrchestratorInstance(), OrchestratorFactory()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), XPoster.SenderPlugins, SendAsync()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, if(), foreach(), FeedOrchestrator()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 121 - "Entity (Community 121)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 112 - "Entity (Community 112)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, XPoster.Orchestrators, GetProfiles()

### Community 118 - "Entity (Community 118)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Contracts, Enums.cs

### Community 132 - "Entity (Community 132)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 124 - "Entity (Community 124)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 125 - "Entity (Community 125)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, XPoster.Credentials, IgCredentials.cs

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 129 - "Entity (Community 129)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 128 - "Entity (Community 128)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 140 - "Entity (Community 140)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

