# Graph Report - XPoster  (2026-06-26)

## Summary
- 1133 nodes · 1918 edges · 138 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Services` - 2 edges
2. `XPoster.Models` - 2 edges
3. `XPoster.Services` - 2 edges
4. `XPoster.Orchestrators` - 2 edges
5. `XPoster.Extensions` - 2 edges
6. `RSSFeed` - 2 edges
7. `XPoster.Models` - 2 edges
8. `Post` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Services` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_FalAi_MissingImagesArray_ReturnsEmptyArray(), ParseImageResponseAsync_FalAi_EmptyImagesArray_ReturnsEmptyArray(), ParseChatCompletionResponseAsync_WhenChoicesIsNull_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.12
Nodes (34): OpenAiServiceTests.cs, OpenAiServiceTests.cs, OpenAiServiceTests, XPoster.Tests.Services, GetSummaryAsync_WhenApiReturnsTooManyRequests_ReturnsEmpty(), GetSummaryAsync_WhenApiReturns200_ReturnsTrimmedContent(), GetSummaryAsync_WhenApiReturnsError_ReturnsEmpty(), GetImagePromptAsync_WhenApiReturnsTooManyRequests_LogsInformation() (+26 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, new(), AiServiceHelperImageTests, Parse_UnsupportedProvider_ReturnsEmpty(), static(), return(), Parse_OpenAi_EmptyDataArray_ReturnsEmpty(), Parse_NonSuccessStatus_ReturnsEmpty() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.12
Nodes (32): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_ReturnsNullEntry_WhenReSummarisationFails(), OrchestrateAsync_GeneratesBaseSummaryAtPrimaryMaxLength(), OrchestrateAsync_DerivesImagePromptFromRawBaseSummary_BeforeHashtags(), OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit(), OrchestrateAsync_SharesImageBytes_AcrossSenders(), OrchestrateAsync_Should_ApplyHashtagsCorrectly() (+24 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, OrchestratorFactoryTests(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn(), PowerLawProfile(), Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactoryWithProfiles() (+22 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, SectionName_IsAzureFoundry(), OptionsExtensionsTests, PerplexityOptionsExtensionsTests, register(), AddDeepSeekOptions_RegistersValidator(), AddFalAiOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.17
Nodes (23): PerplexityServiceTests.cs, PerplexityServiceTests.cs, foreach(), BuildService(), ChatCompletionJson(), PerplexityServiceTests, XPoster.Tests.Services, GetSummaryAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent() (+15 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.19
Nodes (21): IgSenderTests.cs, IgSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSenderWithFactory(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), SendAsync_WithImage_TriesUploadAndReturnsFalse(), SendAsync_WhenInstagramApiReturns429_ReturnsFalse() (+13 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.19
Nodes (20): DryRunSenderTests.cs, DryRunSenderTests.cs, DryRunSenderTests(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), DryRunSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WithImageBytes_ReturnsTrue() (+12 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.11
Nodes (19): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetImagePromptAsync_WhenApiReturnsValidResponse_ReturnsPrompt(), GetImagePromptAsync_WhenChoicesIsNull_ReturnsEmptyString(), GetSummaryAsync_WhenApiReturns429_ReturnsEmptyString(), GetSummaryAsync_PostsToFoundryChatCompletionsEndpoint(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray() (+11 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.20
Nodes (19): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, MakeHandlerMock(), XPoster.Tests.Services, GetSummaryAsync_WhenTextWithinLimit_DoesNotCallApi(), GetSummaryAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsContent(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString() (+11 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), SendAsync(), new(), GetFeedsAsync_ReturnsEmpty_WhenHttpFails() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.12
Nodes (17): AzureFoundryServiceTests.cs, GetSummaryAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GetSummaryAsync_WhenChoicesIsNull_ReturnsEmptyString(), if(), HttpResponseMessage(), GetSummaryAsync_WhenTextExceedsLimit_CallsApiAndReturnsTrimmedContent(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray(), ChatCompletionJson() (+9 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, FeedOrchestratorSlot_Should_HaveTextProviderConfigured(), DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), FeedOrchestratorSlot_Should_ContainLinkedInAndX(), FeedOrchestratorSlot_Should_HaveLinkedInAsFirstSender(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders() (+7 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, XPoster.Tests.Models, Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties(), RSSFeed_PublishDate_DefaultsToMinValue() (+6 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.27
Nodes (14): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests, Validate_WhenImagePromptUserTemplateMissingSummary_ReturnsFailed(), Validate_WhenDeploymentNameIsEmpty_ReturnsFailed(), Validate_WhenImagePromptSystemTemplateHasNoPlaceholder_ReturnsSuccess(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed() (+6 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.29
Nodes (13): InSenderMissingBranchTests.cs, InSenderMissingBranchTests.cs, SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), BuildSender(), InSenderMissingBranchTests(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_NullPost_ReturnsFalse(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse() (+5 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.29
Nodes (13): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, Validate_MissingTextPlaceholder_ErrorNamesProperty(), Validate_MissingTextPlaceholder_Fails(), ValidOptions(), XPoster.Tests.Models, Validate_MissingSummaryPlaceholder_ErrorNamesProperty(), Validate_MissingMaxCharsPlaceholder_ErrorNamesProperty() (+5 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_ModelIdWithAllowedSpecialChars_Succeeds(), ValidOptions(), Validate_WhitespaceApiKey_Fails(), Validate_WhitespaceModelId_Fails(), Validate_ModelIdWithUnsafeCharacters_Fails() (+5 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.29
Nodes (13): OpenAiService.cs, OpenAiService.cs, while(), XPoster.Services, OpenAiService(), GenerateImageAsync(), if(), GetPromptForImage() (+5 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour() (+5 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.32
Nodes (12): DeepSeekService.cs, DeepSeekService.cs, XPoster.Services, DeepSeekService(), var(), GetChatCompletionsEndpoint(), while(), if() (+4 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), XPoster.Tests.Orchestrators, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnReadOnlyDictionary(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull() (+4 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.32
Nodes (12): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, typeof(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), ScheduledOrchestrationProfileTests (+4 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.32
Nodes (12): PerplexityService.cs, PerplexityService.cs, GetImagePromptAsync(), GetSummaryAsync(), XPoster.Services, var(), while(), if() (+4 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.32
Nodes (12): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), XPoster.Tests.SenderPlugins, PostWithoutImage(), PostWithImage(), IgSender() (+4 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, XPoster.Tests.Services, GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning() (+4 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, new(), PowerLawOrchestratorTests(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), XPoster.Tests.Orchestrators, GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate() (+4 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.18
Nodes (11): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageService(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError() (+3 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), ValidPost(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), InSenderResilienceTests (+3 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.35
Nodes (11): XSenderMissingBranchTests.cs, XSenderMissingBranchTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), XSenderMissingBranchTests, XPoster.Tests.SenderPlugins, SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), MessageMaxLenght_Returns250(), SendAsync_NullPost_ReturnsFalse() (+3 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnReadOnlyList(), ConfigurationFeedUrlProvider(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnConfiguredUrls_When_OptionsContainsUrls(), ConfigurationFeedUrlProviderTests (+3 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.38
Nodes (10): XSenderTests.cs, XSenderTests.cs, XSender_ImplementsISender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_InitializesCorrectly(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse() (+2 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, XPoster.Tests.Orchestrators, SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsEmptyList(), Build(), Name_IsNoOrchestrator(), NoOrchestratorTests (+2 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.42
Nodes (9): RSSFeedMissingBranchTests.cs, RSSFeedMissingBranchTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedMissingBranchTests, RSSFeed_CanSetPublishDate(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_SameValues_AreEqual() (+1 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace() (+1 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, AcquireFeedContentAsync(), foreach(), ApplyTagReplacements(), catch(), FeedOrchestrator(), XPoster.Orchestrators (+1 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.42
Nodes (9): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), AzureFoundryOptionsTests, AzureFoundryOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), XPoster.Tests.Models, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.22
Nodes (9): InSender.cs, catch(), Exception(), generatePayLoad(), InvalidOperationException(), SendAsync(), ResolveAuthorUrn(), XPoster.SenderPlugins (+1 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_ImagePromptUserTemplate_ContainsSummaryPlaceholder(), DeepSeekOptions_SummaryUserPromptTemplate_ContainsTextPlaceholder(), DeepSeekOptions_SummarySystemPromptTemplate_ContainsMaxCharsPlaceholder(), DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty() (+1 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.42
Nodes (9): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails(), DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated() (+1 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, HttpResponseMessage(), params(), XPoster.Tests.Integration, var(), BuildSequenceHandler(), BuildDelayedHandler() (+1 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoService(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric() (+1 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.46
Nodes (8): OpenAIResponse.cs, OpenAIResponse.cs, Choice, ImageData, Message, XPoster.Models, OpenAIResponse, OpenAIImageResponse

### Community 49 - "Entity (Community 49)"
Cohesion: 0.25
Nodes (8): AzureFoundryService.cs, GetSummaryAsync(), XPoster.Services, GetImagePromptAsync(), GetChatCompletionsEndpoint(), BuildSummaryPayload(), AzureFoundryService(), GenerateImageAsync()

### Community 50 - "Entity (Community 50)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_DescriptionMatchesEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 44 - "Entity (Community 44)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 46 - "Entity (Community 46)"
Cohesion: 0.46
Nodes (8): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingPlaceholders_Fails()

### Community 45 - "Entity (Community 45)"
Cohesion: 0.46
Nodes (8): PostMissingBranchTests.cs, PostMissingBranchTests.cs, PostMissingBranchTests, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties()

### Community 47 - "Entity (Community 47)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, IsEnabled(), CreateLogger(), CaptureLogger(), CaptureLoggerProvider(), Dispose()

### Community 48 - "Entity (Community 48)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 59 - "Entity (Community 59)"
Cohesion: 0.52
Nodes (7): FalAiImageService.cs, FalAiImageService.cs, if(), GenerateImageAsync(), FalAiImageService(), catch(), XPoster.Services

### Community 60 - "Entity (Community 60)"
Cohesion: 0.29
Nodes (7): AiServiceHelper.cs, ExtractOpenAiBytes(), ExtractFalAiBytesAsync(), LogAndReturnEmpty(), ParseImageResponseAsync(), XPoster.Services, ExtractAzureFoundryBytesAsync()

### Community 57 - "Entity (Community 57)"
Cohesion: 0.52
Nodes (7): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), XPoster.Tests, XFunctionTests(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled()

### Community 55 - "Entity (Community 55)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, catch(), var(), if(), GetImageGenerationEndpoint(), while(), BuildImagePromptPayload()

### Community 56 - "Entity (Community 56)"
Cohesion: 0.52
Nodes (7): XFunctionMissingBranchTests.cs, XFunctionMissingBranchTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_Rethrow_When_Factory_Throws(), XFunctionMissingBranchTests(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), XPoster.Tests

### Community 54 - "Entity (Community 54)"
Cohesion: 0.52
Nodes (7): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, GetProfiles(), XPoster.Orchestrators, ScheduledOrchestrationProfile(), DryRunSlotProfileProvider(), typeof()

### Community 53 - "Entity (Community 53)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XPoster, XFunction(), Run(), if(), catch()

### Community 58 - "Entity (Community 58)"
Cohesion: 0.29
Nodes (7): InSenderTests.cs, BuildCreds(), XPoster.Tests.SenderPlugins, Constructor_InitializesCorrectly(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException()

### Community 52 - "Entity (Community 52)"
Cohesion: 0.29
Nodes (7): FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Orchestrators, OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ProviderReturnsEmptyList(), OrchestrateAsync_Should_CallGetFeedUrls_Once(), new(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url()

### Community 62 - "Entity (Community 62)"
Cohesion: 0.60
Nodes (6): HttpClientExtensions.cs, HttpClientExtensions.cs, AddHttpClients(), IsTransientHttpFailure(), XPoster.Extensions, AddResilientHttpClient()

### Community 61 - "Entity (Community 61)"
Cohesion: 0.60
Nodes (6): FalAiOptionsValidator.cs, FalAiOptionsValidator.cs, if(), foreach(), Validate(), XPoster.Models

### Community 65 - "Entity (Community 65)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, SendAsync(), if(), DryRunSender(), XPoster.SenderPlugins

### Community 68 - "Entity (Community 68)"
Cohesion: 0.60
Nodes (6): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, GetSummaryAsync(), GetImagePromptAsync(), XPoster.Contracts

### Community 66 - "Entity (Community 66)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), XPoster.Tests.Services, TimeProviderTests, GetCurrentTime_ReturnsUtcTime()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), var(), MakeDownloadClient(), JsonResponse(), HttpClient()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 64 - "Entity (Community 64)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, Uri(), DefaultAzureCredential(), if(), DryRunSlotProfileProvider()

### Community 63 - "Entity (Community 63)"
Cohesion: 0.33
Nodes (6): InSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), InSenderTests(), InSender()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, XPoster.Contracts, PostAsync(), IOrchestrator

### Community 90 - "Entity (Community 90)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), ITagReplacementProvider, XPoster.Contracts

### Community 76 - "Entity (Community 76)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Services, GetCurrentTime()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), XPoster.Orchestrators, GetProfiles()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, GetCryptoValue(), ICryptoService

### Community 75 - "Entity (Community 75)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 73 - "Entity (Community 73)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), IFeedUrlProvider, XPoster.Contracts

### Community 71 - "Entity (Community 71)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, XPoster.Orchestrators, GetFeedUrls(), ConfigurationFeedUrlProvider()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, ITextToImageProvider, GenerateImageAsync()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, Resolve(), foreach(), return(), XPoster.Orchestrators

### Community 78 - "Entity (Community 78)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 86 - "Entity (Community 86)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Contracts

### Community 81 - "Entity (Community 81)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), XPoster.Services, GetFeedsAsync(), catch()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Services, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Orchestrators, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Contracts, ITimeProvider

### Community 85 - "Entity (Community 85)"
Cohesion: 0.40
Nodes (5): IgSender.cs, catch(), XPoster.SenderPlugins, UploadImageToPublicUrl(), SendAsync()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Abstraction

### Community 103 - "Entity (Community 103)"
Cohesion: 0.50
Nodes (4): OrchestratorFactory.cs, CreateOrchestratorInstance(), if(), OrchestratorFactory()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 106 - "Entity (Community 106)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 107 - "Entity (Community 107)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, XPoster.Services, catch(), GetCryptoValue()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, AddPerplexityOptions(), XPoster.Models

### Community 93 - "Entity (Community 93)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 91 - "Entity (Community 91)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), catch(), StringContent()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 110 - "Entity (Community 110)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 100 - "Entity (Community 100)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, catch(), SendAsync()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), catch(), return()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, XPoster.Models, AddDeepSeekOptions()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 96 - "Entity (Community 96)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Abstraction, ScheduledOrchestrationProfile()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.50
Nodes (4): FeedOrchestratorFeedUrlProviderTests.cs, FeedOrchestratorFeedUrlProviderTests(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), CreateOrchestrator()

### Community 120 - "Entity (Community 120)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, IgCredentials.cs, IgCredentials.cs

### Community 133 - "Entity (Community 133)"
Cohesion: 0.67
Nodes (3): OpenAiOptionsValidator.cs, Validate(), XPoster.Models

### Community 132 - "Entity (Community 132)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, FeedOptions.cs, XPoster.Models

### Community 130 - "Entity (Community 130)"
Cohesion: 0.67
Nodes (3): AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models

### Community 121 - "Entity (Community 121)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.67
Nodes (3): DeepSeekOptionsValidator.cs, XPoster.Models, Validate()

### Community 131 - "Entity (Community 131)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 122 - "Entity (Community 122)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 123 - "Entity (Community 123)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 124 - "Entity (Community 124)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.67
Nodes (3): PerplexityOptionsValidator.cs, Validate(), XPoster.Models

### Community 127 - "Entity (Community 127)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 128 - "Entity (Community 128)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 126 - "Entity (Community 126)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 119 - "Entity (Community 119)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 112 - "Entity (Community 112)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.67
Nodes (3): IgSender.cs, IgSender(), if()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 118 - "Entity (Community 118)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 117 - "Entity (Community 117)"
Cohesion: 1.00
Nodes (3): Enums.cs, Enums.cs, XPoster.Contracts

### Community 115 - "Entity (Community 115)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, DeepSeekOptions.cs, XPoster.Models

### Community 116 - "Entity (Community 116)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, XPoster.Models, TagReplacementOptions.cs

### Community 137 - "Entity (Community 137)"
Cohesion: 1.00
Nodes (2): OpenAiOptionsValidator.cs, if()

### Community 135 - "Entity (Community 135)"
Cohesion: 1.00
Nodes (2): DeepSeekOptionsValidator.cs, if()

### Community 134 - "Entity (Community 134)"
Cohesion: 1.00
Nodes (2): PerplexityOptionsValidator.cs, if()

### Community 136 - "Entity (Community 136)"
Cohesion: 1.00
Nodes (2): AzureFoundryOptionsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

