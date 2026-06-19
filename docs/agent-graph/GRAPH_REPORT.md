# Graph Report - XPoster  (2026-06-19)

## Summary
- 985 nodes · 1664 edges · 127 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `FalAiImageServiceTests` - 2 edges
2. `XPoster.Tests.Services` - 2 edges
3. `LocalOverrideTimeProviderTests` - 2 edges
4. `XPoster.Tests` - 2 edges
5. `XPoster.Tests.Contracts` - 2 edges
6. `XPoster.Services` - 2 edges
7. `ISender` - 2 edges
8. `ICryptoService` - 2 edges
9. `XPoster.Contracts` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_AzureFoundry_ValidB64Json_ReturnsDecodedBytes(), ParseImageResponseAsync_AzureFoundry_UrlFallback_WrongOrigin_ReturnsEmptyArray(), ParseImageResponseAsync_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning(), AiServiceHelperTests, AzureFoundryUrlJson(), AzureFoundryB64Json() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.07
Nodes (30): AiServiceHelperImageTests.cs, static(), return(), XPoster.Tests.Services, Parse_UnsupportedProvider_LogsError(), Parse_Returns429_LogsWarning(), Parse_Returns429_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError() (+22 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse(), SendAsync_WhenInstagramApiReturns429_ReturnsFalse(), MessageMaxLenght_Returns2200(), SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError() (+16 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString() (+13 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, BuildSender(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), DryRunSender_ImplementsISender(), SendAsync_WithNullPost_ReturnsFalse(), ValidPost() (+12 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString() (+11 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), HttpResponseMessage(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning() (+9 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, KeyVaultService_MissingKeyVaultUri_ThrowsInvalidOperationException(), IgSender_SendAsync_WithoutImage_DoesNotRequestIgSecrets(), InSender_SendAsync_RequestsLinkedInAccessToken(), InSender_SendAsync_RequestsLinkedInOwnerCode(), InSenderKv(), GetSecretAsync_ThrowsWhenSecretNotFound() (+8 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags(), OpenAIImageResponse_CanBeCreated_WithData(), Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), OpenAIResponse_CanBeCreated_WithChoices() (+6 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, MessageMaxLenght_Returns800(), BuildKv(), BuildSender(), InSenderMissingBranchTests(), if(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse() (+6 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, new(), FeedOrchestratorTests(), CreateOrchestrator(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ApplyHashtagsCorrectly(), OrchestrateAsync_Should_ReturnNull_When_AiServiceIsNull() (+6 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), LocalOverrideTimeProvider(), XPoster.Tests.Services, LocalOverrideTimeProviderTests, Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceModelId_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_ModelIdWithAllowedSpecialChars_Succeeds() (+5 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingMaxCharsPlaceholder_Fails(), Validate_DefaultOptions_Succeeds(), OpenAiOptionsValidatorTests, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_Fails() (+5 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, InSenderTests(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_CalledTwice_QueriesKvAccessTokenOnEachCall(), SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), InSender_ImplementsISender() (+5 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, XPoster.Services, if(), var(), OpenAiService(), while(), GetSummary() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalAiImageServiceTests, BuildService(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+4 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithImage(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), PostWithoutImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), XPoster.Tests.SenderPlugins (+4 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnReadOnlyList(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), Constructor_Should_Throw_When_OptionsIsNull() (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), MakeHandlerMock() (+3 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, HybridAiServiceTests, MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), BuildHybrid(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt(), DeepSeekService() (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Orchestrators, new(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_ReturnNull_And_DisableSendIt_When_ProviderReturnsEmptyList() (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), BuildSender(), InSender(), InSenderResilienceTests, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost() (+3 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, XSender_ImplementsISender(), Constructor_InitializesCorrectly(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins, SendAsync_CalledTwice_QueriesKvOnEachCall(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+3 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_NullPost_ReturnsFalse(), BuildSender(), MessageMaxLenght_Returns250(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse() (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, XPoster.Tests.Orchestrators, Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), OrchestratorFactory(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRunSend(), Resolve_Should_ResolveInSender_WhenProfileUsesInSummaryFeed(), Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed() (+2 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), SendIt_Set_ThrowsNotImplementedException(), XPoster.Tests.Orchestrators, ProduceImage_IsAlwaysFalse(), OrchestrateAsync_ReturnsNull(), Name_IsNoOrchestrator() (+2 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse() (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptionsTests (+1 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeedMissingBranchTests, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate() (+1 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), XPoster.Tests.Integration, BuildSequenceHandler(), BuildProviderWithHandler(), BuildDelayedHandler(), params() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests(), XPoster.Tests.Orchestrators, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GenerateImageAsync(), XPoster.Services, GetSummaryAsync(), GetImagePromptAsync(), GetChatCompletionsEndpoint(), BuildSummaryPayload(), AzureFoundryService()

### Community 36 - "Entity (Community 36)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_EmptyContent_IsAllowed(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), XPoster.Tests.Models, PostMissingBranchTests

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Choice, XPoster.Models, OpenAIImageResponse, ImageData, OpenAIResponse, Message

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, CaptureLoggerProvider(), Dispose(), CreateLogger(), CaptureLogger(), IsEnabled()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, GetByProvider(), ArgumentException(), XPoster.Orchestrators, InvalidOperationException(), AiServiceFactory(), if()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.25
Nodes (8): InSender.cs, SendAsync(), generatePayLoad(), ResolveAuthorUrnAsync(), InvalidOperationException(), Exception(), XPoster.SenderPlugins, using()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests, Validate_MissingPlaceholders_Fails()

### Community 37 - "Entity (Community 37)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, FeedServiceTests(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), GetFeedsAsync_FiltersByKeyword_AndDate(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), XPoster.Tests.Services

### Community 38 - "Entity (Community 38)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), XPoster.Tests.Orchestrators, GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), AiServiceFactoryTests()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), LogAndReturnEmpty(), ParseImageResponseAsync(), XPoster.Services, ExtractFalAiBytesAsync(), ExtractOpenAiBytes()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_Rethrow_When_Factory_Throws(), XFunctionMissingBranchTests(), XPoster.Tests, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), XPoster.Tests.Contracts

### Community 49 - "Entity (Community 49)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), GetImageGenerationEndpoint(), catch(), BuildImagePromptPayload(), var(), if()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, CreateFactoryWithProfiles(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne(), OrchestratorFactoryTests(), SetupMocksForOrchestratorFactory(), CreateFactory(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.29
Nodes (7): DeepSeekService.cs, BuildSummaryPayload(), XPoster.Services, while(), GenerateImageAsync(), GetSummaryAsync(), if()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.52
Nodes (7): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, if(), GenerateImageAsync(), catch(), FalAiImageService(), XPoster.Services

### Community 46 - "Entity (Community 46)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GetSummaryAsync(), GetImagePromptAsync(), IAiService, XPoster.Contracts, GenerateImageAsync()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, HybridAiService(), GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync(), XPoster.Services

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), DryRunSender(), catch(), if()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, IsTransientHttpFailure(), AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, IKeyVaultService, XPoster.Contracts, GetSecretAsync(), SetSecretAsync()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), Validate(), if(), XPoster.Models

### Community 58 - "Entity (Community 58)"
Cohesion: 0.33
Nodes (6): DeepSeekService.cs, var(), DeepSeekService(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), BuildImagePromptPayload()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeDownloadClient(), HttpClient(), JsonResponse(), MakeNoOpClient(), var()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, SetSecretAsync(), GetSecretAsync(), XPoster.Services, KeyVaultService()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, foreach(), XPoster.Orchestrators, Resolve(), return(), ResolveAiProvider()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Orchestrators, ScheduledOrchestrationProfile(), DryRunSlotProfileProvider(), GetProfiles()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, XPoster.Tests.Services

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), XPoster.Tests, Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XFunctionTests()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildDeepSeekService(), BuildFalService(), HybridAiService()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, PostAsync(), XPoster.Contracts

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Contracts

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Services, TimeProvider

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), XPoster.Contracts, IFeedUrlProvider

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), XPoster.Services, GetCurrentTime()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Contracts

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, GetCurrentTime(), ITimeProvider

### Community 73 - "Entity (Community 73)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, IOrchestratorFactory, Resolve()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), XPoster.SenderPlugins, UploadImageToPublicUrl(), catch()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 76 - "Entity (Community 76)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, GetFeedsAsync(), Exception(), catch()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, XPoster.Orchestrators, catch(), GenerateMessage(), ReplaceEveryFirstOccurenceOf()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, XPoster.Contracts, GetByProvider(), IAiServiceFactory

### Community 91 - "Entity (Community 91)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, foreach(), FeedOrchestrator(), if()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Abstraction, BaseOrchestrator()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 88 - "Entity (Community 88)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 93 - "Entity (Community 93)"
Cohesion: 0.83
Nodes (4): Program.cs, Program.cs, DryRunSlotProfileProvider(), if()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), BuildSequenceHandler(), XPoster.Tests.Helpers

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), XPoster.SenderPlugins, SendAsync()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 101 - "Entity (Community 101)"
Cohesion: 0.50
Nodes (4): XFunction.cs, XPoster, Run(), catch()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, OrchestratorFactory(), CreateOrchestratorInstance(), if()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): InSender.cs, if(), InSender(), catch()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, XPoster.Orchestrators, GetProfiles()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 105 - "Entity (Community 105)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 109 - "Entity (Community 109)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 121 - "Entity (Community 121)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 118 - "Entity (Community 118)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 110 - "Entity (Community 110)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Contracts, Enums.cs

### Community 112 - "Entity (Community 112)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 113 - "Entity (Community 113)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 122 - "Entity (Community 122)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 124 - "Entity (Community 124)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 125 - "Entity (Community 125)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

