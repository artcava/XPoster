# Graph Report - XPoster  (2026-06-26)

## Summary
- 1133 nodes · 1918 edges · 138 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Extensions` - 2 edges
2. `XPoster.SenderPlugins` - 2 edges
3. `XPoster.Orchestrators` - 2 edges
4. `XPoster.Tests.Integration` - 2 edges
5. `XPoster` - 2 edges
6. `XPoster.Contracts` - 2 edges
7. `IOrchestrator` - 2 edges
8. `XPoster.Contracts` - 2 edges
9. `ITagReplacementProvider` - 2 edges
10. `XPoster.Contracts` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AzureFoundryUrlJson(), AzureFoundryB64Json(), ParseImageResponseAsync_OpenAi_EmptyDataArray_ReturnsEmptyArray(), ParseImageResponseAsync_OpenAi_EmptyB64JsonValue_ReturnsEmptyArray(), ParseImageResponseAsync_FalAi_ValidUrl_ReturnsDownloadedBytes(), ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GetImagePromptAsync_WhenApiReturns200_ReturnsTrimmedContent(), GetImagePromptAsync_WhenApiReturnsError_ReturnsEmpty(), GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), MakeHandler(), OpenAiService(), MakeHandlerMock() (+26 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, new(), AiServiceHelperImageTests, Parse_UnsupportedProvider_ReturnsEmpty(), return(), static(), Parse_Returns429_ReturnsEmpty(), Parse_OpenAi_MissingDataProperty_ReturnsEmpty() (+24 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.12
Nodes (32): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsWhitespace(), OrchestrateAsync_Should_ReturnPostWithUnmodifiedContent_When_ProviderReturnsEmptyReplacements(), OrchestrateAsync_Should_UseSummaryAsPrompt_When_GetImagePromptAsyncReturnsEmpty(), OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit(), OrchestrateAsync_DerivesImagePromptFromRawBaseSummary_BeforeHashtags() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactory(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), CreateFactoryWithProfiles(), Resolve_Should_RequestDifferentKeys_WhenTextAndImageProvidersAreDifferent(), Resolve_Should_RequestTextProviderKey_WhenProfileSpecifiesTextProvider() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, BuildConfig(), AddPerplexityOptions_BindsOptionsFromCorrectSection(), AddPerplexityOptions_RegistersValidator(), AzureFoundryOptionsExtensionsTests, AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GetSummaryAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt() (+15 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSenderWithFactory(), Constructor_InitializesCorrectly(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhitespaceContent_ReturnsFalse() (+13 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithImageBytes_ReturnsTrue(), SendAsync_WithNullPost_LogsWarning(), SendAsync_WithNullPost_ReturnsFalse(), ValidPost(), SendAsync_WhenProbeKeyPresent_LogsPostContent() (+12 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturns429_ReturnsEmptyString(), GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), DeepSeekServiceTests (+11 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, XPoster.Tests.Services, GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateImageAsync_WhenApiReturnsTooManyRequests_LogsWarning() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), FakeHttpMessageHandler(), FeedServiceTests, FeedService(), foreach(), SendAsync() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetImagePromptAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_LogsError(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests, FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), FeedOrchestratorSlot_Should_ContainLinkedInAndX(), FeedOrchestratorSlot_Should_HaveLinkedInAsFirstSender(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured() (+7 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenSummaryUserPromptMissingText_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), XPoster.Tests.Models, ValidOptions(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess() (+6 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanHold_ImageBytes(), Post_Firm_ContainsExpectedHashtags(), RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, RSSFeed_CanBeCreated_WithAllProperties(), OpenAIResponse_CanBeCreated_WithChoices() (+6 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_Fails(), OpenAiOptionsValidatorTests, Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty(), Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_AllPlaceholdersMissing_ReportsThreeFailures() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ModelIdWithAllowedSpecialChars_Succeeds(), ValidOptions(), Validate_WhitespaceApiKey_Fails(), Validate_WhitespaceModelId_Fails(), Validate_ModelIdWithUnsafeCharacters_Fails() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), BuildProvider(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind() (+5 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, catch(), XPoster.Services, OpenAiService(), GenerateImageAsync(), GetImagePromptAsync(), if() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), XPoster.Tests.SenderPlugins (+5 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, new(), IgSender(), PostWithImage(), BuildSender(), IgSenderResilienceTests, PostWithoutImage() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), CreateOrchestrator(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), XPoster.Tests.Orchestrators (+4 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnReadOnlyDictionary(), Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationTagReplacementProviderTests, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), foreach() (+4 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, while(), BuildSummaryPayload(), if(), GetSummaryAsync(), GetChatCompletionsEndpoint(), DeepSeekService() (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied(), Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied() (+4 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, var(), while(), XPoster.Services, if(), GetSummaryAsync(), BuildSummaryPayload() (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalImageJson(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri() (+4 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), BuildSender(), InSender(), InSenderResilienceTests, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError() (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, XPoster.Tests.Orchestrators, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), Constructor_Should_Throw_When_OptionsIsNull() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+3 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, XPoster.Tests.SenderPlugins, XSenderMissingBranchTests, SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), MessageMaxLenght_Returns250(), SendAsync_NullPost_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse() (+3 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XPoster.Tests.SenderPlugins, SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning() (+2 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), SendIt_Set_ThrowsNotImplementedException(), OrchestrateAsync_ReturnsEmptyList(), Build(), SendIt_IsAlwaysFalse(), NoOrchestratorTests (+2 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, var(), BuildSequenceHandler(), BuildDelayedHandler(), BuildProviderWithHandler(), HttpResponseMessage(), params() (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), AzureFoundryOptionsTests, XPoster.Tests.Models (+1 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails() (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder() (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, catch(), generatePayLoad(), SendAsync(), ResolveAuthorUrn(), using(), Exception() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, AcquireFeedContentAsync(), ApplyTagReplacements(), catch(), FeedOrchestrator(), foreach(), if() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), XPoster.Tests.Services, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoServiceTests, CryptoService() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XSenderSendAsyncTests(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse() (+1 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, PostMissingBranchTests, Post_EmptyContent_IsAllowed(), Post_CanSetAndGetAllProperties(), Firm_IsNotNullOrEmpty(), Post_DefaultImageIsNull(), XPoster.Tests.Models

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, AzureFoundryOptionsValidatorTests, Validate_MissingPlaceholders_Fails()

### Community 51 - "Entity (Community 51)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_DescriptionMatchesEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString(), AiProviderExtensionsTests

### Community 49 - "Entity (Community 49)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetSummaryAsync(), XPoster.Services, GetImagePromptAsync(), GetChatCompletionsEndpoint(), BuildSummaryPayload(), AzureFoundryService(), GenerateImageAsync()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 44 - "Entity (Community 44)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, Dispose(), CaptureLogger(), CreateLogger(), CaptureLoggerProvider(), IsEnabled()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, ImageData, Choice, OpenAIResponse, XPoster.Models, Message, OpenAIImageResponse

### Community 59 - "Entity (Community 59)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), new(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), XPoster.Tests.Orchestrators

### Community 57 - "Entity (Community 57)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, typeof(), XPoster.Orchestrators, GetProfiles(), ScheduledOrchestrationProfile(), DryRunSlotProfileProvider()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, catch(), XFunction(), Run(), if()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, Constructor_InitializesCorrectly(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins, BuildCreds()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_Rethrow_When_Factory_Throws(), XFunctionMissingBranchTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XPoster.Tests

### Community 60 - "Entity (Community 60)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, FalAiImageService(), catch(), GenerateImageAsync(), if(), XPoster.Services

### Community 52 - "Entity (Community 52)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 54 - "Entity (Community 54)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), catch(), var(), GetImageGenerationEndpoint(), BuildImagePromptPayload(), if()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractFalAiBytesAsync(), XPoster.Services, ParseImageResponseAsync(), LogAndReturnEmpty(), ExtractOpenAiBytes(), ExtractAzureFoundryBytesAsync()

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpClients(), IsTransientHttpFailure()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), DryRunSender(), if()

### Community 66 - "Entity (Community 66)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), for(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), Uri(), DryRunSlotProfileProvider(), DefaultAzureCredential()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, foreach(), if(), Validate(), XPoster.Models

### Community 70 - "Entity (Community 70)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSender()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, XPoster.Contracts, GetImagePromptAsync(), GetSummaryAsync()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), JsonResponse(), MakeNoOpClient(), MakeDownloadClient(), HttpClient()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Services, TimeProviderTests, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), StringContent(), XPoster.Tests.Integration

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, XPoster.Contracts, GenerateImageAsync()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, IOrchestrator, PostAsync()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), IFeedUrlProvider, XPoster.Contracts

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), if(), XPoster.Orchestrators

### Community 81 - "Entity (Community 81)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), UploadImageToPublicUrl(), XPoster.SenderPlugins, SendAsync()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Services, TimeProvider, GetCurrentTime()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, catch()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Services, LocalOverrideTimeProvider()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), catch(), XPoster.Services, GetFeedsAsync()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, XPoster.Contracts, SendAsync(), ISender

### Community 90 - "Entity (Community 90)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), GetProfiles(), XPoster.Orchestrators

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, foreach(), Resolve(), return(), XPoster.Orchestrators

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), ITimeProvider, XPoster.Contracts

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Orchestrators, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), XPoster.Abstraction, PostAsync()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, XPoster.Models, AddOpenAiOptions()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), return(), if()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 95 - "Entity (Community 95)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 98 - "Entity (Community 98)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 99 - "Entity (Community 99)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 92 - "Entity (Community 92)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, catch(), SendAsync()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Abstraction

### Community 102 - "Entity (Community 102)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, XPoster.Models, AddFalAiOptions()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 104 - "Entity (Community 104)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (3): Enums.cs, XPoster.Contracts, Enums.cs

### Community 112 - "Entity (Community 112)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, XPoster.Models, Validate()

### Community 113 - "Entity (Community 113)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 118 - "Entity (Community 118)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, IgCredentials.cs, IgCredentials.cs

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 116 - "Entity (Community 116)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, XPoster.Models, Validate()

### Community 120 - "Entity (Community 120)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 133 - "Entity (Community 133)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 132 - "Entity (Community 132)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 121 - "Entity (Community 121)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 129 - "Entity (Community 129)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 124 - "Entity (Community 124)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FeedOptions.cs, FeedOptions.cs

### Community 128 - "Entity (Community 128)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

