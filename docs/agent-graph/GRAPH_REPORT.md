# Graph Report - XPoster  (2026-06-22)

## Summary
- 1089 nodes · 1839 edges · 140 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `HybridAiServiceTests` - 2 edges
2. `XPoster.Tests.Services` - 2 edges
3. `FalAiOptionsExtensionsTests` - 2 edges
4. `OpenAiOptionsExtensionsTests` - 2 edges
5. `XPoster.Services` - 2 edges
6. `XPoster.Services` - 2 edges
7. `XPoster.Extensions` - 2 edges
8. `XPoster.Tests.Services` - 2 edges
9. `XPoster.Models` - 2 edges
10. `TimeProviderTests` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, FalAiJson(), ChatJson(), MakeHttpClient(), HttpClient(), MakeResponse(), MakeHttpClientThatThrows() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenSummaryAlwaysTooLong_StopsAfterThreeAttempts(), GetImagePromptAsync_WhenApiReturnsError_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation(), GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.07
Nodes (30): AiServiceHelperImageTests.cs, new(), AiServiceHelperImageTests, Parse_OpenAi_ValidB64_ReturnsBytes(), Parse_OpenAi_EmptyB64Value_ReturnsEmpty(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty(), Parse_FalAi_DownloadThrows_ReturnsEmpty() (+22 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddFalAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator(), ConfigurationBuilder(), BuildConfig(), BuildProvider() (+21 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.15
Nodes (26): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityServiceTests, XPoster.Tests.Services, MakeSequentialHandlerMock(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), MakeHandlerMock() (+18 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.17
Nodes (23): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_ResolveXSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram(), Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles() (+15 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, DeepSeekService(), BuildService(), ChatCompletionJson(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateImageAsync_AlwaysThrows_NotSupportedException(), GenerateImageAsync_ExceptionMessage_MentionsHybridAiService() (+13 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WhenImageUploadThrowsNotImplemented_ReturnsFalseAndLogsError(), MessageMaxLenght_Returns2200(), new(), SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+13 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WithImageBytes_ReturnsTrue(), SendAsync_WithNullPost_LogsWarning(), ValidPost(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WhenProbeKeyMissing_ReturnsFalse() (+12 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), AzureFoundryServiceTests (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, SendAsync(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), new(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), BuildService() (+10 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_RequestBodyContainsModelField(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray() (+9 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, OpenAIResponse_CanBeCreated_WithChoices(), RSSFeed_PublishDate_DefaultsToMinValue(), RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags(), Post_CanHold_ImageBytes(), Post_CanBeCreated_WithRequiredContent() (+6 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.27
Nodes (14): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), FeedOrchestratorTests(), CreateOrchestrator() (+6 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_NullPost_ReturnsFalse(), BuildCreds(), MessageMaxLenght_Returns800(), InSenderMissingBranchTests(), BuildSender(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceModelId_Fails(), Validate_MissingModelId_Fails(), Validate_ModelIdWithAllowedSpecialChars_Succeeds(), Validate_ModelIdWithUnsafeCharacters_Fails(), Validate_ValidOptions_Succeeds(), Validate_WhitespaceApiKey_Fails() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GenerateImageAsync(), GetSummary(), GetImagePromptAsync(), GetPromptForImage(), GetSummaryAsync(), if() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails(), ValidOptions() (+5 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, BuildService(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+4 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithImage(), XPoster.Tests.SenderPlugins, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), PostWithoutImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+4 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError() (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, HybridAiServiceTests, MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_DelegatesToDeepSeek_ReturnsContent(), BuildHybrid(), FalAiImageService(), DeepSeekService() (+3 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, BuildSender(), InSenderResilienceTests, XPoster.Tests.SenderPlugins, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError() (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedUrls_Once(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_ReturnNull_And_DisableSendIt_When_ProviderReturnsEmptyList(), FeedOrchestratorFeedUrlProviderTests(), CreateOrchestrator(), new() (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProvider(), Constructor_Should_Throw_When_OptionsIsNull(), GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnReadOnlyList() (+3 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, XSenderMissingBranchTests, SendAsync_WhitespaceContent_ReturnsFalse(), BuildSender(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse() (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins (+2 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_Set_ThrowsNotImplementedException(), XPoster.Tests.Orchestrators, OrchestrateAsync_ReturnsNull(), ProduceImage_IsAlwaysFalse(), Name_IsNoOrchestrator(), NoOrchestratorTests() (+2 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.22
Nodes (9): InSender.cs, ResolveAuthorUrn(), generatePayLoad(), Exception(), catch(), InvalidOperationException(), XPoster.SenderPlugins, using() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), MakeService(), CryptoServiceTests, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), XPoster.Tests.Services (+1 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), PowerLawOrchestratorTests(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis() (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), XPoster.Tests.Models (+1 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, HttpResponseMessage(), params(), var(), XPoster.Tests.Integration, BuildProviderWithHandler(), BuildDelayedHandler() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptionsTests, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, if(), AiServiceFactory(), GetByProvider(), ArgumentException(), InvalidOperationException(), XPoster.Orchestrators

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, OpenAIImageResponse, XPoster.Models, OpenAIResponse, Message, ImageData, Choice

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CreateLogger(), CaptureLoggerProvider(), XPoster.Tests.Integration, IsEnabled(), CaptureLogger(), Dispose()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.25
Nodes (8): PerplexityService.cs, XPoster.Services, nameof(), GetSummaryAsync(), if(), GetImagePromptAsync(), GenerateImageAsync(), while()

### Community 39 - "Entity (Community 39)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, XPoster.Tests.Models, Firm_IsNotNullOrEmpty(), Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), PostMissingBranchTests, Post_CanSetAndGetAllProperties()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, AiServiceFactoryTests(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), XPoster.Tests.Orchestrators, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, AzureFoundryService(), XPoster.Services, BuildSummaryPayload(), GetChatCompletionsEndpoint(), GenerateImageAsync(), GetSummaryAsync(), GetImagePromptAsync()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, BuildImagePromptPayload(), GetImageGenerationEndpoint(), while(), if(), var(), catch()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ParseImageResponseAsync(), XPoster.Services, LogAndReturnEmpty(), ExtractOpenAiBytes(), ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), XPoster.Services, if(), GenerateImageAsync(), FalAiImageService()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, XPoster.Tests, Run_Should_LogError_When_PostAsync_ReturnsFalse(), XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Contracts, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, GenerateImageAsync(), GetImagePromptAsync(), GetSummaryAsync(), IAiService, XPoster.Contracts

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), BuildCreds(), XPoster.Tests.SenderPlugins

### Community 52 - "Entity (Community 52)"
Cohesion: 0.29
Nodes (7): DeepSeekService.cs, GenerateImageAsync(), BuildSummaryPayload(), while(), XPoster.Services, GetSummaryAsync(), if()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, GetImagePromptAsync(), GenerateImageAsync(), XPoster.Services, GetSummaryAsync(), HybridAiService()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration

### Community 69 - "Entity (Community 69)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeDownloadClient(), HttpClient(), JsonResponse(), MakeNoOpClient()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.33
Nodes (6): PerplexityService.cs, PerplexityService(), GetChatCompletionsEndpoint(), BuildImagePromptPayload(), BuildSummaryPayload(), var()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), XPoster.Extensions, IsTransientHttpFailure(), AddResilientHttpClient()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services, TimeProviderTests

### Community 65 - "Entity (Community 65)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSenderTests(), InSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, XPoster.Models, Validate(), if(), foreach()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): DeepSeekService.cs, var(), GetChatCompletionsEndpoint(), DeepSeekService(), BuildImagePromptPayload(), GetImagePromptAsync()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, Resolve(), XPoster.Orchestrators, return(), ResolveAiProvider(), foreach()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, SendAsync(), DryRunSender(), XPoster.SenderPlugins, if()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, HybridAiService(), BuildFalService(), BuildDeepSeekService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DryRunSlotProfileProvider(), DefaultAzureCredential(), if(), Uri()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile(), XPoster.Orchestrators

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, TimeProvider, GetCurrentTime()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, GetCryptoValue(), XPoster.Contracts

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Contracts, IFeedService

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 89 - "Entity (Community 89)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), IOrchestrator, XPoster.Contracts

### Community 87 - "Entity (Community 87)"
Cohesion: 0.40
Nodes (5): IgSender.cs, UploadImageToPublicUrl(), catch(), SendAsync(), XPoster.SenderPlugins

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), XPoster.Orchestrators, ConfigurationFeedUrlProvider()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), XPoster.Services, Exception(), catch()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, GetByProvider(), XPoster.Contracts, IAiServiceFactory

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, XPoster.Contracts, GetFeedUrls()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, GetCurrentTime(), ITimeProvider

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), XPoster.Services, GetCurrentTime()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, catch(), XPoster.Orchestrators, GenerateMessage(), ReplaceEveryFirstOccurenceOf()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), PowerLawOrchestrator(), XPoster.Orchestrators

### Community 110 - "Entity (Community 110)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), return(), catch()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 91 - "Entity (Community 91)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 103 - "Entity (Community 103)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 104 - "Entity (Community 104)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 105 - "Entity (Community 105)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), BuildSequenceHandler(), XPoster.Tests.Helpers

### Community 108 - "Entity (Community 108)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, FeedOrchestrator(), if(), foreach()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), XPoster, catch()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Abstraction, PostAsync()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): XFunction.cs, XFunction(), if()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 112 - "Entity (Community 112)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 115 - "Entity (Community 115)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 118 - "Entity (Community 118)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 133 - "Entity (Community 133)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 132 - "Entity (Community 132)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Contracts, Enums.cs

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Orchestrators

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 124 - "Entity (Community 124)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, XPoster.Credentials, IgCredentials.cs

### Community 126 - "Entity (Community 126)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 129 - "Entity (Community 129)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

