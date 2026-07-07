# Graph Report - XPoster  (2026-07-07)

## Summary
- 1133 nodes · 1918 edges · 138 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `PerplexityOptionsValidatorTests` - 2 edges
2. `XPoster.Tests.SenderPlugins` - 2 edges
3. `XPoster.Tests.Models` - 2 edges
4. `RSSFeedMissingBranchTests` - 2 edges
5. `XPoster.Tests.Orchestrators` - 2 edges
6. `XPoster.Credentials` - 2 edges
7. `XPoster.Models` - 2 edges
8. `XPoster.Models` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AzureFoundryUrlJson(), ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName(), AzureFoundryB64Json(), ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty(), OpenAiB64Json() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiService(), MakeHandler(), MakeHandlerMock(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmpty(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmpty() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (32): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_ReturnsNullEntry_WhenReSummarisationFails(), OrchestrateAsync_DerivesImagePromptFromRawBaseSummary_BeforeHashtags(), OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit(), OrchestrateAsync_GeneratesBaseSummaryAtPrimaryMaxLength(), OrchestrateAsync_ThirdSender_ReusesSecondSummary_WhenSecondFitsAndThirdDoesNot(), OrchestrateAsync_SkipsAICall_WhenBaseSummaryFitsSecondaryLimit() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_UnsupportedProvider_ReturnsEmpty(), static(), return(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_MalformedJson_ReturnsEmpty(), Parse_NonSuccessStatus_ReturnsEmpty(), Parse_OpenAi_EmptyB64Value_ReturnsEmpty() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider(), OrchestratorFactoryTests(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn(), PowerLawProfile(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactoryWithProfiles() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), BuildConfig(), AddPerplexityOptions_BindsOptionsFromCorrectSection(), AddPerplexityOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, PerplexityServiceTests, XPoster.Tests.Services, GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), MakeHandlerMock(), MakeSequentialHandlerMock(), GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi() (+15 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, IgSender(), Constructor_InitializesCorrectly(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithImage_TriesUploadAndReturnsFalse(), SendAsync_WhenInstagramApiReturns429_ReturnsFalse() (+13 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, DryRunSender_ImplementsISender(), BuildSender(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenProbeKeyPresent_LogsPostContent(), new() (+12 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GenerateImageAsync_WhenPromptIsEmpty_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenB64JsonAbsentAndUrlPresent_DownloadsFromUrl(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), XPoster.Tests.Services, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, BuildRssXml(), XPoster.Tests.Services, BuildFactory(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), FakeHttpMessageHandler(), FeedService() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), ChatCompletionJson(), AzureFoundryService(), GetSummaryAsync_RequestBodyContainsModelField(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, GetProfiles_Should_HaveUniqueHours(), FeedOrchestratorSlot_Should_ContainLinkedInAndX(), FeedOrchestratorSlot_Should_HaveTwoSenders(), FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders() (+7 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), PerplexityOptionsValidatorTests, Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), XPoster.Tests.Models (+6 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanHold_ImageBytes(), XPoster.Tests.Models, RSSFeed_PublishDate_DefaultsToMinValue(), RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags(), Choice_CanBeCreated_WithMessage() (+6 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), BuildSender(), InSenderMissingBranchTests(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, if(), while(), XPoster.Services, OpenAiService(), var(), GetSummaryAsync() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models, Validate_WhitespaceModelId_Fails(), Validate_MissingApiKey_Fails(), Validate_WhitespaceApiKey_Fails() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingMaxCharsPlaceholder_Fails(), XPoster.Tests.Models, Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_Fails(), Validate_MissingTextPlaceholder_Fails(), Validate_MissingTextPlaceholder_ErrorNamesProperty() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), LocalOverrideTimeProviderTests, LocalOverrideTimeProvider() (+5 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), CreateOrchestrator(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, XPoster.Tests.Abstraction, Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_PreserveOrderOfSenderPlatforms(), ScheduledOrchestrationProfileTests (+4 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, XPoster.Tests.Orchestrators, Constructor_Should_Throw_When_OptionsIsNull(), GetReplacements_Should_ReturnReadOnlyDictionary(), foreach(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries() (+4 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, GetImagePromptAsync(), GetSummaryAsync(), BuildImagePromptPayload(), BuildSummaryPayload(), GetChatCompletionsEndpoint(), var() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, PostWithImage(), XPoster.Tests.SenderPlugins, PostWithoutImage(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError() (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, GetSummaryAsync(), if(), while(), var(), XPoster.Services, GetChatCompletionsEndpoint() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderMissingBranchTests, SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_NullPost_ReturnsFalse(), MessageMaxLenght_Returns250() (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), InSender(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), InSenderResilienceTests, BuildSender(), ValidPost() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), MakeHandlerMock(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray() (+3 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), ConfigurationFeedUrlProviderTests, Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationFeedUrlProvider(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls() (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSender_ImplementsISender(), XPoster.Tests.SenderPlugins, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_InitializesCorrectly(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+2 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), XPoster.Tests.Orchestrators, SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests (+2 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, XPoster.Tests.Models, RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedMissingBranchTests, RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildDelayedHandler(), BuildProviderWithHandler(), BuildSequenceHandler(), params(), HttpResponseMessage(), XPoster.Tests.Integration (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_Defaults_AreCorrect() (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, foreach(), if(), XPoster.Orchestrators, FeedOrchestrator(), AcquireFeedContentAsync(), ApplyTagReplacements() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoServiceTests, XPoster.Tests.Services, MakeService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), XPoster.Tests.Models, AzureFoundryOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptionsTests (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingPlaceholders_Fails(), XPoster.Tests.Models (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.22
Nodes (9): InSender.cs, SendAsync(), catch(), generatePayLoad(), InvalidOperationException(), Exception(), ResolveAuthorUrn(), XPoster.SenderPlugins (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), XPoster.Tests.Contracts, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent() (+1 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, InSenderSendAsyncTests()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, PostMissingBranchTests, XPoster.Tests.Models, Post_DefaultImageIsNull(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), Post_EmptyContent_IsAllowed()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, OpenAIResponse, XPoster.Models, OpenAIImageResponse, Message, Choice, ImageData

### Community 51 - "Entity (Community 51)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), CaptureLoggerProvider(), XPoster.Tests.Integration, IsEnabled(), Dispose(), CreateLogger()

### Community 49 - "Entity (Community 49)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_When_Content_IsEmpty()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingPlaceholders_Fails(), XPoster.Tests.Models, AzureFoundryOptionsValidatorTests, ValidOptions(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, AzureFoundryService(), BuildSummaryPayload(), XPoster.Services, GenerateImageAsync(), GetChatCompletionsEndpoint(), GetImagePromptAsync(), GetSummaryAsync()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), AiProviderExtensionsTests, GetLabel_DescriptionDiffersFromEnumName()

### Community 59 - "Entity (Community 59)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), BuildCreds(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), new()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, BuildImagePromptPayload(), while(), catch(), var(), if(), GetImageGenerationEndpoint()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests, XFunctionMissingBranchTests(), Run_Should_Rethrow_When_Factory_Throws()

### Community 60 - "Entity (Community 60)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, FalAiImageService(), catch(), GenerateImageAsync(), if(), XPoster.Services

### Community 55 - "Entity (Community 55)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), XFunction(), Run(), if(), XPoster

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), ScheduledOrchestrationProfile(), typeof(), XPoster.Orchestrators, DryRunSlotProfileProvider()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractOpenAiBytes(), ExtractAzureFoundryBytesAsync(), XPoster.Services, LogAndReturnEmpty(), ExtractFalAiBytesAsync(), ParseImageResponseAsync()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, GetImagePromptAsync(), GetSummaryAsync(), XPoster.Contracts, ITextToTextProvider

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeDownloadClient(), JsonResponse(), HttpClient(), var(), MakeNoOpClient()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSenderTests()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), XPoster.SenderPlugins, SendAsync(), DryRunSender()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, IsTransientHttpFailure(), AddResilientHttpClient(), AddHttpClients(), XPoster.Extensions

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, DefaultAzureCredential(), Uri(), if(), DryRunSlotProfileProvider()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, XPoster.Tests.Services, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), foreach(), Validate(), XPoster.Models

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Contracts, Resolve()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Contracts, IOrchestrator

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, IFeedUrlProvider, GetFeedUrls()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider(), GetCurrentTime(), XPoster.Services

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Contracts, ITimeProvider

### Community 85 - "Entity (Community 85)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, foreach(), return(), XPoster.Orchestrators, Resolve()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, GetCryptoValue(), ICryptoService

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, XPoster.Orchestrators, GetProfiles(), ScheduledOrchestrationProfile()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 87 - "Entity (Community 87)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, catch(), XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, if(), PowerLawOrchestrator()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Services, GetCurrentTime()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), Exception(), GetFeedsAsync(), XPoster.Services

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, ISlotProfileProvider, GetProfiles()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.40
Nodes (5): IgSender.cs, SendAsync(), catch(), UploadImageToPublicUrl(), XPoster.SenderPlugins

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Orchestrators, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Abstraction

### Community 95 - "Entity (Community 95)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, if(), OrchestratorFactory(), CreateOrchestratorInstance()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 99 - "Entity (Community 99)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 91 - "Entity (Community 91)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), catch(), return()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, CreateOrchestrator(), FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 107 - "Entity (Community 107)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 104 - "Entity (Community 104)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, BuildSequenceHandler(), var()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 120 - "Entity (Community 120)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 132 - "Entity (Community 132)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 129 - "Entity (Community 129)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 131 - "Entity (Community 131)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 125 - "Entity (Community 125)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Contracts, Enums.cs

### Community 127 - "Entity (Community 127)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 128 - "Entity (Community 128)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 126 - "Entity (Community 126)"
Cohesion: 0.67
Nodes (3): IgSender.cs, if(), IgSender()

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 112 - "Entity (Community 112)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, XPoster.Models, Validate()

### Community 111 - "Entity (Community 111)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 114 - "Entity (Community 114)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 118 - "Entity (Community 118)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (3): IgCredentials.cs, XPoster.Credentials, IgCredentials.cs

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

