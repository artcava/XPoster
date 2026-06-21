# Graph Report - XPoster  (2026-06-21)

## Summary
- 1096 nodes · 1853 edges · 140 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Services` - 2 edges
2. `XPoster.Orchestrators` - 2 edges
3. `XPoster.Tests.Helpers` - 2 edges
4. `XPoster.Orchestrators` - 2 edges
5. `XPoster.Models` - 2 edges
6. `XPoster` - 2 edges
7. `XPoster.Services` - 2 edges
8. `XPoster.Services` - 2 edges
9. `IgSenderResilienceTests` - 2 edges
10. `XPoster.Tests.Orchestrators` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AiServiceHelperTests, MakeResponse(), MakeHttpClientThatThrows(), ParseImageResponseAsync_FalAi_ValidUrl_ReturnsDownloadedBytes(), ParseImageResponseAsync_FalAi_MissingImagesArray_ReturnsEmptyArray(), ParseImageResponseAsync_FalAi_MissingUrlProperty_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.07
Nodes (30): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_ValidB64_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_WrongOrigin_LogsWarning() (+22 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddOpenAiOptions_RegistersValidator(), AddPerplexityOptions_RegistersValidator(), AddPerplexityOptions_BindsOptionsFromCorrectSection(), XPoster.Tests.Models, SectionName_IsOpenAI(), SectionName_IsDeepSeek() (+21 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.15
Nodes (26): PerplexityServiceTests.cs, PerplexityServiceTests.cs, MakeHandlerMock(), PerplexityServiceTests, PerplexityService(), MakeSequentialHandlerMock(), GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+18 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.16
Nodes (24): IgSenderTests.cs, IgSenderTests.cs, Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), IgSender(), IgSenderTests(), MessageMaxLenght_Returns2200(), SendAsync_WhenImageUploadThrowsHttpRequestException_ReturnsFalseAndLogsError() (+16 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (21): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), MakeHandlerMock(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+13 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, ValidPost(), SendAsync_WithImageBytes_LogsImagePresence(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithNullPost_LogsWarning(), Constructor_WithNullKeyVaultService_ThrowsArgumentNullException(), BuildSender() (+12 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, AzureFoundryServiceTests, BuildService(), GenerateImageAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), ChatCompletionJson(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+9 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.24
Nodes (16): KeyVaultServiceTests.cs, KeyVaultServiceTests.cs, XPoster.Tests.Services, KeyVaultServiceTests, InSender_SendAsync_RequestsLinkedInOwnerCode(), InSenderKv(), KeyVaultService_MissingKeyVaultUri_ThrowsInvalidOperationException(), StubHttpMessageHandler() (+8 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.27
Nodes (14): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, InSenderMissingBranchTests(), BuildKv(), if(), BuildSender(), XPoster.Tests.SenderPlugins, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse() (+6 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.27
Nodes (14): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsNull(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_ApplyHashtagsCorrectly() (+6 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_CanBeCreated_WithAllProperties(), OpenAIImageResponse_CanBeCreated_WithData(), Post_CanHold_ImageBytes(), OpenAIResponse_CanBeCreated_WithChoices(), Post_CanBeCreated_WithRequiredContent(), Post_Firm_ContainsExpectedHashtags() (+6 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests, Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed() (+6 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): InSenderTests.cs, InSenderTests.cs, SendAsync_WhenLinkedInOrgIdPresent_UsesOrgIdAndSkipsOwnerCode(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), BuildKeyVaultMock(), BuildKeyVaultMockWithOrg() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceApiKey_Fails(), Validate_WhitespaceModelId_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingApiKey_Fails() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetSummary(), OpenAiService(), GetSummaryAsync(), if(), var(), while() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_AllPlaceholdersMissing_ReportsThreeFailures(), OpenAiOptionsValidatorTests, Validate_DefaultOptions_Succeeds(), ValidOptions(), Validate_MissingMaxCharsPlaceholder_Fails() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, BuildProvider(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), IgSenderResilienceTests, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), PostWithImage(), PostWithoutImage(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), BuildService(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), FalAiImageServiceTests, FalImageJson(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), MessageMaxLenght_Returns250(), BuildSender(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.18
Nodes (11): HybridAiServiceTests.cs, MakeHandlerMock(), ChatCompletionJson(), Constructor_NullDeepSeekService_ThrowsArgumentNullException(), HybridAiServiceTests, FalAiImageService(), DeepSeekService(), GetImagePromptAsync_DelegatesToDeepSeek_ReturnsPrompt() (+3 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), CreateOrchestrator(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls() (+3 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray() (+3 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.35
Nodes (11): XSenderTests.cs, XSenderTests.cs, BuildKeyVaultMock(), SendAsync_CalledTwice_QueriesKvOnEachCall(), Constructor_InitializesCorrectly(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnReadOnlyList(), Constructor_Should_Throw_When_OptionsIsNull() (+3 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, ProduceImage_IsAlwaysFalse(), OrchestrateAsync_ReturnsNull(), Name_IsNoOrchestrator(), NoOrchestratorTests(), SendIt_Set_ThrowsNotImplementedException(), XPoster.Tests.Orchestrators (+2 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.20
Nodes (10): OrchestratorFactoryTests.cs, Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), XPoster.Tests.Orchestrators, Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveXSender_WhenProfileUsesXSummaryFeed(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), OrchestratorFactory(), Resolve_Should_NotRequestAiProvider_WhenProfileHasNoAiProvider() (+2 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildSequenceHandler(), BuildDelayedHandler(), BuildProviderWithHandler(), var(), XPoster.Tests.Integration, HttpResponseMessage() (+1 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests(), GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), XPoster.Tests.Orchestrators, GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests() (+1 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), DeepSeekOptionsValidatorTests, Validate_MissingPlaceholders_Fails(), Validate_MissingRequiredProperties_Fails(), ValidOptions(), Validate_ValidOptions_Succeeds() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), XPoster.Tests.Models, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests, XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue() (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_Defaults_AreCorrect() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.46
Nodes (8): AiServiceFactoryTests.cs, AiServiceFactoryTests.cs, XPoster.Tests.Orchestrators, GetByProvider_Should_ThrowInvalidOperationException_When_MappedServiceCannotBeResolved(), GetByProvider_Should_ReturnService_When_ProviderIsMappedAndResolvable(), GetByProvider_Should_ThrowArgumentException_When_ProviderIsNotMapped(), GetByProvider_Should_ReturnAzureFoundryService_When_ProviderIsMappedAndResolvable(), AiServiceFactoryTests()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, Dispose(), IsEnabled(), XPoster.Tests.Integration, CaptureLoggerProvider(), CaptureLogger(), CreateLogger()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), Validate_MissingPlaceholders_Fails(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails()

### Community 40 - "Entity (Community 40)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, Post_DefaultImageIsNull(), XPoster.Tests.Models, PostMissingBranchTests, Post_EmptyContent_IsAllowed(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), InSenderSendAsyncTests()

### Community 42 - "Entity (Community 42)"
Cohesion: 0.25
Nodes (8): PerplexityService.cs, GenerateImageAsync(), XPoster.Services, while(), if(), GetImagePromptAsync(), nameof(), GetSummaryAsync()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.25
Nodes (8): InSender.cs, ResolveAuthorUrnAsync(), generatePayLoad(), Exception(), InvalidOperationException(), using(), SendAsync(), XPoster.SenderPlugins

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, OpenAIResponse, OpenAIImageResponse, Choice, ImageData, Message, XPoster.Models

### Community 39 - "Entity (Community 39)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, BuildSummaryPayload(), GenerateImageAsync(), GetImagePromptAsync(), GetChatCompletionsEndpoint(), XPoster.Services, GetSummaryAsync(), AzureFoundryService()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): AiServiceFactory.cs, AiServiceFactory.cs, AiServiceFactory(), GetByProvider(), InvalidOperationException(), if(), ArgumentException(), XPoster.Orchestrators

### Community 49 - "Entity (Community 49)"
Cohesion: 0.46
Nodes (8): FeedServiceTests.cs, FeedServiceTests.cs, XPoster.Tests.Services, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_SetsCache_WhenFeedsFetched(), GetFeedsAsync_ReturnsEmpty_WhenInvalidFeed(), FeedServiceTests(), GetFeedsAsync_FiltersByKeyword_AndDate()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, XPoster.Services, ParseImageResponseAsync(), ExtractOpenAiBytes(), ExtractFalAiBytesAsync(), ExtractAzureFoundryBytesAsync(), LogAndReturnEmpty()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), FalAiImageService(), GenerateImageAsync(), XPoster.Services, if()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, if(), GetImageGenerationEndpoint(), BuildImagePromptPayload(), catch(), while(), var()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): HybridAiService.cs, HybridAiService.cs, XPoster.Services, GenerateImageAsync(), GetImagePromptAsync(), GetSummaryAsync(), HybridAiService()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), XPoster.Tests.Contracts, PostAsync_ReturnsTrue_When_AllConditionsMet()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.29
Nodes (7): DeepSeekService.cs, GetSummaryAsync(), while(), BuildSummaryPayload(), GenerateImageAsync(), if(), XPoster.Services

### Community 60 - "Entity (Community 60)"
Cohesion: 0.52
Nodes (7): DryRunSender.cs, DryRunSender.cs, if(), DryRunSender(), catch(), SendAsync(), XPoster.SenderPlugins

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests, XFunctionMissingBranchTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsNull()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.52
Nodes (7): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.52
Nodes (7): IAiService.cs, IAiService.cs, XPoster.Contracts, IAiService, GetSummaryAsync(), GenerateImageAsync(), GetImagePromptAsync()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.29
Nodes (7): OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), OrchestratorFactoryTests(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactory(), CreateFactoryWithProfiles(), Resolve_Should_RequestConfiguredAiProvider_WhenProfileSpecifiesOne()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), IsTransientHttpFailure(), AddHttpClients()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.33
Nodes (6): DeepSeekService.cs, DeepSeekService(), GetImagePromptAsync(), GetChatCompletionsEndpoint(), var(), BuildImagePromptPayload()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.33
Nodes (6): PerplexityService.cs, GetChatCompletionsEndpoint(), var(), PerplexityService(), BuildSummaryPayload(), BuildImagePromptPayload()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, Validate(), if(), foreach(), XPoster.Models

### Community 74 - "Entity (Community 74)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, foreach(), ResolveAiProvider(), return(), XPoster.Orchestrators, Resolve()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.33
Nodes (6): HybridAiServiceTests.cs, HybridAiService(), BuildFalService(), Constructor_NullFalAiService_ThrowsArgumentNullException(), BuildDeepSeekService(), GenerateImageAsync_DelegatesToFalAi_NotToDeepSeek()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.60
Nodes (6): IKeyVaultService.cs, IKeyVaultService.cs, IKeyVaultService, GetSecretAsync(), XPoster.Contracts, SetSecretAsync()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), StringContent(), XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, TestOrchestrator(), BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), DryRunSlotProfileProvider(), ScheduledOrchestrationProfile(), XPoster.Orchestrators

### Community 64 - "Entity (Community 64)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services, TimeProviderTests, GetCurrentTime_ReturnsUtcTime()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeDownloadClient(), HttpClient(), MakeNoOpClient(), JsonResponse()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): KeyVaultService.cs, KeyVaultService.cs, XPoster.Services, GetSecretAsync(), KeyVaultService(), SetSecretAsync()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, catch(), GenerateMessage(), XPoster.Orchestrators, ReplaceEveryFirstOccurenceOf()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), XPoster.Orchestrators, GetFeedUrls()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), XPoster.Tests.Integration

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, GetCurrentTime(), TimeProvider

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): IAiServiceFactory.cs, IAiServiceFactory.cs, XPoster.Contracts, IAiServiceFactory, GetByProvider()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Contracts

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Orchestrators, PowerLawOrchestrator()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 89 - "Entity (Community 89)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), Exception(), GetFeedsAsync(), XPoster.Services

### Community 88 - "Entity (Community 88)"
Cohesion: 0.40
Nodes (5): IgSender.cs, UploadImageToPublicUrl(), XPoster.SenderPlugins, catch(), SendAsync()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Contracts

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, IFeedUrlProvider, GetFeedUrls(), XPoster.Contracts

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), ICryptoService, XPoster.Contracts

### Community 96 - "Entity (Community 96)"
Cohesion: 0.83
Nodes (4): Program.cs, Program.cs, if(), DryRunSlotProfileProvider()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, var(), XPoster.Tests.Helpers, BuildSequenceHandler()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): XFunction.cs, Run(), catch(), XPoster

### Community 103 - "Entity (Community 103)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): InSender.cs, InSender(), if(), catch()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, OrchestratorFactory(), if(), CreateOrchestratorInstance()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Abstraction, PostAsync(), BaseOrchestrator()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 111 - "Entity (Community 111)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 106 - "Entity (Community 106)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 108 - "Entity (Community 108)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 110 - "Entity (Community 110)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, foreach(), if(), FeedOrchestrator()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 113 - "Entity (Community 113)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 115 - "Entity (Community 115)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, Validate(), XPoster.Models

### Community 119 - "Entity (Community 119)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 122 - "Entity (Community 122)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Contracts, Enums.cs

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 132 - "Entity (Community 132)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, GetProfiles(), XPoster.Orchestrators

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 126 - "Entity (Community 126)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 128 - "Entity (Community 128)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 129 - "Entity (Community 129)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 127 - "Entity (Community 127)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 139 - "Entity (Community 139)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 138 - "Entity (Community 138)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

