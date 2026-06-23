# Graph Report - XPoster  (2026-06-23)

## Summary
- 1074 nodes · 1812 edges · 137 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Contracts` - 2 edges
2. `XPoster.Contracts` - 2 edges
3. `XPoster.Abstraction` - 2 edges
4. `XPoster.Tests.Models` - 2 edges
5. `AiProviderExtensionsTests` - 2 edges
6. `ImageData` - 2 edges
7. `Choice` - 2 edges
8. `XPoster.Models` - 2 edges
9. `OpenAIResponse` - 2 edges
10. `OpenAIImageResponse` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_WhenMalformedJson_ReturnsEmptyArray(), ParseImageResponseAsync_WhenMalformedJson_LogsError(), ParseImageResponseAsync_UnsupportedProvider_ReturnsEmptyArray(), ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray(), ParseChatCompletionResponseAsync_WhenValidResponse_ReturnsTrueAndTrimmedContent(), OpenAiB64Json() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsError_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_FalAi_DownloadThrows_LogsError(), Parse_FalAi_DownloadThrows_ReturnsEmpty(), Parse_FalAi_EmptyImagesArray_ReturnsEmpty(), Parse_OpenAi_EmptyB64Value_ReturnsEmpty(), Parse_MalformedJson_ReturnsEmpty(), Parse_NonSuccessStatus_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, SectionName_IsOpenAI(), SectionName_IsPerplexity(), XPoster.Tests.Models, new(), OpenAiOptionsExtensionsTests, OptionsExtensionsTests (+21 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, foreach(), ChatCompletionJson(), BuildService(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString() (+15 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, SendAsync_WhenInstagramApiReturns429_ReturnsFalse(), SendAsync_WhenInstagramApiReturnsNonSuccess_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithImage_TriesUploadAndReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhitespaceContent_ReturnsFalse() (+13 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithNullPost_LogsWarning(), SendAsync_WithImageBytes_ReturnsTrue(), SendAsync_WhenProbeKeyMissing_LogsError() (+12 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, BuildService(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), ChatCompletionJson(), DeepSeekService(), DeepSeekServiceTests, XPoster.Tests.Services (+11 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), MakeHandlerMock(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString() (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), XPoster.Tests.Services (+10 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, HttpResponseMessage(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_RequestBodyContainsModelField(), if() (+9 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.23
Nodes (17): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsWhitespace(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationReturnsEmpty(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageProviderIsNull(), OrchestrateAsync_Should_ReturnPostWithoutImage_When_ImageGenerationThrowsException(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsEmpty(), CreateOrchestrator() (+9 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.13
Nodes (15): OrchestratorFactoryTests.cs, Resolve_Should_ResolveXSender_ForPowerLawOrchestrator(), Resolve_Should_RequestImageProviderKey_WhenProfileSpecifiesImageProvider(), Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn(), Resolve_Should_ResolveDryRunSender_WhenProfileUsesDryRun(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram(), Resolve_Should_NotRequestTextProvider_WhenProfileHasNoTextProvider(), OrchestratorFactory() (+7 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, ValidOptions(), Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WhenSummarySystemPromptMissingMaxChars_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), Validate_WhenSummaryUserPromptMissingText_ReturnsFailed() (+6 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Choice_CanBeCreated_WithMessage(), ImageData_CanBeCreated_WithUrl(), Message_CanBeCreated_WithContent(), OpenAIImageResponse_CanBeCreated_WithData(), ModelsTests, RSSFeed_PublishDate_DefaultsToMinValue() (+6 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), XPoster.Tests.SenderPlugins, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, ValidOptions(), XPoster.Tests.Models, Validate_WhitespaceApiKey_Fails(), Validate_MissingApiKey_Fails(), Validate_ValidOptions_Succeeds(), Validate_ModelIdWithUnsafeCharacters_Fails() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, GetSummaryAsync(), XPoster.Services, var(), while(), if(), OpenAiService() (+5 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_AllPlaceholdersMissing_ReportsThreeFailures(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_DefaultOptions_Succeeds(), OpenAiOptionsValidatorTests, Validate_MissingMaxCharsPlaceholder_Fails(), Validate_MissingSummaryPlaceholder_Fails() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, while(), DeepSeekService(), if(), GetSummaryAsync(), GetImagePromptAsync(), var() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithImage(), IgSenderResilienceTests, new(), IgSender(), BuildSender(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError() (+4 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalAiImageServiceTests, BuildService(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, if(), PerplexityService(), var(), while(), XPoster.Services, GetImagePromptAsync() (+4 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.35
Nodes (11): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, GetProfiles_Should_HaveUniqueHours(), FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), DefaultSlotProfileProviderTests, DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), GetProfiles_Should_NotContainDryRunSlot() (+3 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.35
Nodes (11): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), CreateOrchestrator(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls() (+3 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.18
Nodes (11): OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), OrchestratorFactoryTests(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), Resolve_Should_RequestTextProviderKey_WhenProfileSpecifiesTextProvider(), Resolve_Should_ResolveLinkedInSender_ForPowerLawOrchestrator(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn(), Resolve_Should_RequestDifferentKeys_WhenTextAndImageProvidersAreDifferent() (+3 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError() (+3 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, MessageMaxLenght_Returns250(), BuildSender(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse() (+3 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProvider(), Constructor_Should_Throw_When_OptionsIsNull(), XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnReadOnlyList() (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), InSenderResilienceTests, XPoster.Tests.SenderPlugins, ValidPost(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, Constructor_InitializesCorrectly(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), XSenderTests(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse() (+2 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, NoOrchestratorTests(), SendIt_Set_ThrowsNotImplementedException(), OrchestrateAsync_ReturnsNull(), ProduceImage_Set_ThrowsNotImplementedException(), SendIt_IsAlwaysFalse(), XPoster.Tests.Orchestrators (+2 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.38
Nodes (10): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied() (+2 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, using(), InvalidOperationException(), ResolveAuthorUrn(), catch(), Exception(), generatePayLoad() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests, CryptoService() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildDelayedHandler(), HttpResponseMessage(), var(), params(), XPoster.Tests.Integration, BuildProviderWithHandler() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), PowerLawOrchestratorTests() (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, XPoster.Tests.Models, RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedMissingBranchTests, RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XSenderSendAsyncTests() (+1 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), PostMissingBranchTests

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Choice, XPoster.Models, OpenAIResponse, OpenAIImageResponse, Message

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetImagePromptAsync(), BuildSummaryPayload(), GenerateImageAsync(), AzureFoundryService(), GetChatCompletionsEndpoint(), XPoster.Services, GetSummaryAsync()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, CreateLogger(), CaptureLogger(), CaptureLoggerProvider(), Dispose(), IsEnabled()

### Community 43 - "Entity (Community 43)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, AzureFoundryOptionsValidatorTests

### Community 51 - "Entity (Community 51)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, BuildCreds(), Constructor_InitializesCorrectly(), Constructor_WithNullLogger_ThrowsArgumentNullException(), InSender_ImplementsISender(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins

### Community 50 - "Entity (Community 50)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider(), XPoster.Orchestrators, typeof(), GetProfiles(), ScheduledOrchestrationProfile()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), GetImageGenerationEndpoint(), var(), if(), catch(), BuildImagePromptPayload()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.29
Nodes (7): BaseOrchestratorTests.cs, XPoster.Tests.Contracts, PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_ReturnsFalse_When_SendIt_IsFalse()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, catch(), FalAiImageService(), GenerateImageAsync(), if(), XPoster.Services

### Community 56 - "Entity (Community 56)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, XPoster.Services, ParseImageResponseAsync(), ExtractFalAiBytesAsync(), LogAndReturnEmpty(), ExtractOpenAiBytes(), ExtractAzureFoundryBytesAsync()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsNull(), XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws(), XPoster.Tests, Run_Should_LogError_When_PostAsync_ReturnsFalse()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DefaultAzureCredential(), if(), Uri(), DryRunSlotProfileProvider()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, Validate(), if(), foreach(), XPoster.Models

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpClients(), IsTransientHttpFailure()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSenderTests(), InSender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), if(), DryRunSender()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.33
Nodes (6): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_IsNull(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Services, TimeProviderTests

### Community 59 - "Entity (Community 59)"
Cohesion: 0.60
Nodes (6): XFunctionTests.cs, XFunctionTests.cs, Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), XPoster.Tests

### Community 60 - "Entity (Community 60)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, HttpClient(), JsonResponse(), MakeDownloadClient(), MakeNoOpClient(), var()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, ITextToTextProvider, GetSummaryAsync(), GetImagePromptAsync()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), if(), XPoster.Orchestrators

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), XPoster.Contracts, IFeedUrlProvider

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), XPoster.Orchestrators, GetFeedUrls()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, XPoster.Orchestrators, return(), foreach(), Resolve()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Services, LocalOverrideTimeProvider()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, GetCurrentTime(), ITimeProvider

### Community 85 - "Entity (Community 85)"
Cohesion: 0.40
Nodes (5): IgSender.cs, XPoster.SenderPlugins, UploadImageToPublicUrl(), catch(), SendAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 78 - "Entity (Community 78)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, Exception(), catch(), GetFeedsAsync()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Contracts, IOrchestrator

### Community 79 - "Entity (Community 79)"
Cohesion: 0.40
Nodes (5): FeedOrchestrator.cs, catch(), GenerateMessage(), XPoster.Orchestrators, ReplaceEveryFirstOccurenceOf()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Contracts

### Community 69 - "Entity (Community 69)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, GenerateImageAsync(), ITextToImageProvider, XPoster.Contracts

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), TimeProvider, XPoster.Services

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Contracts, IFeedService

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.50
Nodes (4): FeedOrchestrator.cs, foreach(), FeedOrchestrator(), if()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 89 - "Entity (Community 89)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 90 - "Entity (Community 90)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), return(), if()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Abstraction, PostAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 101 - "Entity (Community 101)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 103 - "Entity (Community 103)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 105 - "Entity (Community 105)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): XFunction.cs, catch(), XPoster, Run()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 96 - "Entity (Community 96)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 95 - "Entity (Community 95)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 93 - "Entity (Community 93)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, AddAzureFoundryOptions(), XPoster.Models

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 118 - "Entity (Community 118)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 108 - "Entity (Community 108)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XPoster.Credentials, XCredentials.cs

### Community 109 - "Entity (Community 109)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, XPoster.Credentials, IgCredentials.cs

### Community 110 - "Entity (Community 110)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.67
Nodes (3): XFunction.cs, if(), XFunction()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.67
Nodes (3): DefaultSlotProfileProvider.cs, XPoster.Orchestrators, GetProfiles()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 128 - "Entity (Community 128)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 130 - "Entity (Community 130)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 129 - "Entity (Community 129)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 120 - "Entity (Community 120)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, Enums.cs, Enums.cs

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 125 - "Entity (Community 125)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 124 - "Entity (Community 124)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 132 - "Entity (Community 132)"
Cohesion: 1.00
Nodes (2): BaseOrchestrator.cs, if()

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile()

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

