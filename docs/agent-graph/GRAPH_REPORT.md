# Graph Report - XPoster  (2026-07-30)

## Summary
- 1684 nodes · 2867 edges · 195 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests` - 2 edges
2. `AiModelCatalogTests` - 2 edges
3. `IgSenderImageFlowTests` - 2 edges
4. `PostTests` - 2 edges
5. `XPoster.Tests.Models` - 2 edges
6. `DeepSeekOptionsValidatorTests` - 2 edges
7. `ImageData` - 2 edges
8. `Choice` - 2 edges
9. `Message` - 2 edges
10. `AIResponse` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseChatCompletionResponseAsync_WhenStatusIs429_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenValidResponse_ReturnsTrueAndTrimmedContent(), ParseChatCompletionResponseAsync_WhenStatusIsNonSuccess_ReturnsFalseAndEmpty(), ParseImageResponseAsync_AzureFoundry_UrlFallback_DownloadFails_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_ReturnsNullEntry_WhenReSummarisationFails(), OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit(), OrchestrateAsync_Should_PassNullMaxTokenBudget_ToPromptRequest(), OrchestrateAsync_Should_PassNullInputTextLabel_ToPromptRequest(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_DerivesImagePromptFromRawBaseSummary_BeforeHashtags() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateTextAsync_RequestBodyContainsModelFromOptions(), GenerateImageAsync_WhenInputTextIsWhitespace_ReturnsEmptyByteArrayWithoutCallingApi(), GenerateTextAsync_PostsToChatCompletionsEndpoint(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), AzureFoundryService(), BuildService() (+33 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, XPoster.Tests.Services, OpenAiService(), OpenAiServiceTests, GenerateTextAsync_UsesSystemPromptTemplateFromRequest(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), new(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_NullAllowedOrigin_SkipsOriginCheckAndDownloads() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddAzureFoundryOptions_RegistersValidator(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator(), AddFalAiOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, new(), GenerateTextAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent(), MakeHandlerMock(), MakeSequentialHandlerMock(), PerplexityServiceTests, XPoster.Tests.Services (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, BuildCreds(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), SendAsync_TextOnly_WhenResponseHasEmptyId_ReturnsFalse(), SendAsync_TextOnly_WhenResponseMissingId_ReturnsFalse(), SendAsync_TextOnly_WhenResponseHasNullId_ReturnsFalse(), SendAsync_WithCaptionExceedingMaxLength_TruncatesAndPublishes() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent(), GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsBadGateway_ReturnsEmptyString(), MakeHandlerMock(), HttpResponseMessage() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.09
Nodes (22): OrchestratorFactoryTests.cs, Resolve_Should_ResolveXSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveXSender_WhenProfileUsesX(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), PowerLawProfile(), DefaultSlotProfileProvider_Should_NotContainDryRunProfile(), FeedProfile() (+14 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_EmptyContent_ReturnsFalse(), Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_Returns250(), Platform_ReturnsX(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), BuildSender() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.20
Nodes (19): FeedPromptOptionsTests.cs, FeedPromptOptionsTests.cs, GetStep_EmptySteps_ThrowsInvalidOperationException(), FeedPromptOptions_ValueEquality_SameSteps_AreEqual(), GetStep_DuplicateRole_ThrowsInvalidOperationException(), FeedPromptOptions_WithExpression_PreservesStepsReference(), FeedPromptOptionsTests, FeedPromptOptions_ValueEquality_DifferentSteps_AreNotEqual() (+11 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WithInvalidBytes_ReturnsNull(), IgSenderImageFlowTests, NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull(), NormalizeImage_WhenCodecIsNull_ReturnsNull(), Uri() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), SendAsync(), new(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), BuildService() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, ModelCatalog_UnsupportedCapability_GetRequired_Throws(), FalAiOptions_ModelCatalog_ExposesImageOnly(), FalAiOptions_ImplementsIAiProviderOptions(), ModelCatalog_EmptyModelName_NotExposedAsSupported(), FalAiOptions_NumInferenceSteps_RemainsOnConcreteClass(), DeepSeekOptions_ModelCatalog_ExposesTextOnly() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_ForwardsModelName(), BuildChatPayload_FirstMessageRoleIsSystem(), AiServiceHelperChatPayloadTests, BuildChatPayload_ForwardsMaxTokenBudget(), BuildChatPayload_SystemMessage_NoPlaceholder_IsUnchanged(), BuildChatPayload_InterpolatesMaxCharsInSystemMessage() (+10 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): PromptStepOptionsTests.cs, PromptStepOptionsTests.cs, XPoster.Tests.Models, PromptStepOptions_ValueEquality_DifferentOptionals_AreNotEqual(), PromptStepOptionsTests, PromptStepOptions_ValueEquality_DifferentRole_AreNotEqual(), PromptStepOptions_WithExpression_PreservesUnchangedProperties(), PromptStepOptions_ValueEquality_SameValues_AreEqual() (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_ValueEquality_SameValues_AreEqual(), XPoster.Tests.Models, PromptRequestTests, ImagePromptRequest_InheritsFrom_PromptRequest(), ImagePromptRequest_BaseProperties_AreAccessible(), ImagePromptRequest_ImageProperties_AreSetCorrectly() (+9 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), CreateSut(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), PublishContainerAsync_WhenRateLimited_Throws() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests, GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), GetPendingAsync_ReturnsOnlyPendingEntries(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests, Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged(), Initialize_WhenTelemetryIsNotDependency_DoesNothing(), Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), PostWithImage(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), SendAsync_WhenBlobUploadFails_ReturnsFalse(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests, TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), typeof(), XPoster.Tests.Models, OrchestratorContextKey_Should_BeNull_WhenNotProvided(), Constructor_Should_PreserveHour_ForBoundaryValues() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection(), AddAiProviderOptions_RegistersAllFiveOptionTypes(), AddAiProviderOptions_DoesNotDuplicateValidatorRegistrations_WhenCalledOnce(), AddAiProviderOptions_BindsOpenAiOptions_FromCorrectSection(), AddAiProviderOptions_RegistersAllFiveValidators(), AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection() (+7 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, PowerLawSlot_Should_HaveNullTextAndImageProvider(), XPoster.Tests.Providers, PowerLawSlot_Should_ContainLinkedInAndX(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), GetProfiles_Should_ReturnWellFormedProfiles(), FeedOrchestratorSlot_Should_HaveTextProviderConfigured() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), CreateSut(), BlobStorageService(), BlobStorageServiceTests, Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), XPoster.Tests.Services (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, SendAsync_WhenProbeKeyMissing_ReturnsFalse(), ConfigurationBuilder(), SendAsync_WhenKeyMissing_ReturnsFalse(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), new(), DryRunSender_ImplementsISender(), DryRunSender() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): PromptRoleTests.cs, PromptRoleTests.cs, PromptRole_UndefinedValueNotPresentInMap_ThrowsKeyNotFound(), PromptRole_ParseFromStringIgnoreCase_ReturnsCorrectMember(), PromptRole_ParseInvalidName_Throws(), PromptRole_TryParse_ValidName_ReturnsTrue(), PromptRole_ToString_ReturnsName(), PromptRole_TryParse_InvalidName_ReturnsFalse() (+7 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, foreach(), catch(), XPosterContainerPollingFunction(), XPoster, HandleTerminalFailureAsync(), ProcessContainerAsync() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Post_CanBeCreated_WithRequiredContent(), Post_CanHold_ImageBytes(), RSSFeed_PublishDate_DefaultsToMinValue(), XPoster.Tests.Models, Post_Firm_ContainsExpectedHashtags(), RSSFeed_CanBeCreated_WithAllProperties() (+6 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, Supports_ReturnsFalseForMissingModelClass(), AiModelCatalogTests, Constructor_ExcludesNullOrWhitespaceEntries(), Empty_SupportsNoModelClass(), GetRequired_ReturnsModelName_WhenSupported(), Constructor_NullDictionary_Throws() (+5 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ImageModelNameWithUnsafeCharacters_Fails(), Validate_WhitespaceModelId_Fails(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds(), ValidOptions(), Validate_MissingModelId_Fails() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow(), Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, FalImageJson(), BuildService(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalAiImageServiceTests, GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_Returns429_ReturnsEmptyArray() (+5 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests(), CreateOrchestrator(), new(), GenerateAsync_Should_CalculateCorrectPowerLawValue_ForFixedDate(), GenerateAsync_Should_HandleNegativeOrZeroCryptoValue(), GenerateAsync_Should_CreateCorrectMessage_WithActualValue() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenBlobDeleteFails_LogsError() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WithNullPost_LogsWarning(), Platform_ReturnsDryRun(), DryRunSenderTests(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), MessageMaxLength_ReturnsIntMaxValue(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), SendAsync_WhenProbeKeyPresent_LogsPostContent() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnReadOnlyDictionary(), XPoster.Tests.Providers, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), foreach(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, GetImageGenerationEndpoint(), catch(), GenerateTextAsync(), GetChatCompletionsEndpoint(), GenerateImageAsync(), AzureFoundryService() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, MakeRequest(), FalAiImageService(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, Platform_ReturnsLinkedIn(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_InitializesCorrectly(), BuildSender(), BuildCreds(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), XPoster.Tests.SenderPlugins, Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), MessageMaxLength_Returns2200() (+3 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), XPoster.Tests.Providers, GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), GetFeedUrls_Should_ReturnReadOnlyList(), Constructor_Should_Throw_When_OptionsIsNull() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.18
Nodes (11): OrchestratorFactoryTests.cs, FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), CreateFactory(), OrchestratorFactoryTests(), Resolve_Should_NotRequestTextProvider_WhenProfileHasNoTextProvider(), Resolve_Should_RequestImageProviderKey_WhenProfileSpecifiesImageProvider(), SetupMocksForOrchestratorFactory() (+3 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AiProviderServiceCollectionExtensionsTests, XPoster.Tests.Extensions, AddXPosterAiProviders_ReturnsSameServiceCollection(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSenderResilienceTests, SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests, XFunctionTests(), Run_Should_Rethrow_When_Factory_Throws(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, HttpRequestException(), GetContainerStatusAsync(), catch(), GetApiVersion(), PublishContainerAsync(), XPoster.Services (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildFactory(), BuildCreds(), XPoster.Tests.SenderPlugins, SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyImageArray_ReturnsFalse(), BuildSender(), IgSender(), IgSenderSendAsyncTests, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption() (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, XPoster.SenderPlugins, FbSender(), PublishTextOnlyAsync(), SendAsync(), catch(), HandleResponseAsync() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, Build(), XPoster.Tests.Orchestrators, NoOrchestratorTests, SupportedPlatforms_IsEmpty(), OrchestrateAsync_ReturnsEmptyList(), SendIt_IsAlwaysFalse() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, XSenderResilienceTests, XPoster.Tests.SenderPlugins, BuildSender(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XSender(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WithMultipleInvalidFields_ReturnsAllFailures(), ValidOptions(), XPoster.Tests.Models, Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed() (+2 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, params(), HttpResponseMessage(), BuildSequenceHandler(), BuildDelayedHandler(), BuildProviderWithHandler(), XPoster.Tests.Integration (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_CanSetPublishDate(), XPoster.Tests.Models, RSSFeedTests, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_DefaultPublishDateIsMinValue() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, GetRequired(), TryGet(), Supports(), InvalidOperationException(), if(), XPoster.Models (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_SkipsNullPost_ReturnsFalse() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, Exception(), SendAsync(), ResolveAuthorUrn(), using(), generatePayLoad(), catch() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), for(), catch(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), CryptoServiceTests, CryptoService() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, catch(), foreach(), if(), FeedOrchestrator(), BuildPromptRequest(), XPoster.Orchestrators (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), FbSenderResilienceTests, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), HttpResponseMessage() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), PendingContainer(), CreateTimerInfo() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_ReturnsSameServiceCollection(), XPoster.Tests.Extensions, foreach(), HttpClientExtensionsTests, AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, BuildCreds(), BuildFactory(), InvalidImageBytes(), SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), HttpRequestException(), SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), FbSenderImageFlowTests (+1 more)

### Community 74 - "Entity (Community 74)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ParseImageResponseAsync(), ExtractAzureFoundryBytesAsync(), ExtractOpenAiBytes(), ExtractFalAiBytesAsync(), BuildChatPayload(), LogAndReturnEmpty(), XPoster.Services

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), PostTests, XPoster.Tests.Models, Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, ValidOptions(), Validate_MissingRequiredProperties_Fails(), DeepSeekOptionsValidatorTests, Validate_ValidOptions_Succeeds(), Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), XPoster.Tests.Models

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, ImageData, Choice, Message, AIResponse, OpenAIImageResponse, XPoster.Models

### Community 69 - "Entity (Community 69)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), TestOrchestrator(), BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, GetImageGenerationEndpoint(), catch(), FalAiImageService(), GenerateImageAsync(), XPoster.Services, if()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_DescriptionMatchesEnumName(), XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_UnknownProvider_ReturnsFallbackToString(), AiProviderExtensionsTests

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, XPoster.Services, if(), BlobUploadResult(), BlobStorageService(), UploadAsync(), DeleteAsync()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, IsEnabled(), CaptureLogger(), CreateLogger(), Dispose(), CaptureLoggerProvider()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.25
Nodes (8): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ContextHasNoFeedUrls(), XPoster.Tests.Providers, OrchestrateAsync_TwoSlots_Should_UseDifferentFeedUrls_Independently(), OrchestrateAsync_Should_PassSenderMessageMaxLength_As_MaxOutputLength_In_SummaryRequest(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), catch(), if(), IgSender(), XPoster.SenderPlugins

### Community 87 - "Entity (Community 87)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, SaveAsync(), UpdateStatusAsync(), XPoster.Services, GetPendingAsync(), InMemoryContainerStateStore

### Community 88 - "Entity (Community 88)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), IContainerStateStore, SaveAsync(), UpdateStatusAsync(), XPoster.Contracts

### Community 82 - "Entity (Community 82)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, DryRunSlotProfileProvider(), BlobServiceClient(), DefaultAzureCredential(), Uri(), if()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, typeof(), XPoster.Orchestrators, return(), Resolve(), catch(), foreach()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, XPoster.Services, TagReplacementService(), Apply(), foreach(), if()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, XPoster.Services, GenerateTextAsync(), catch(), GenerateImageAsync(), var(), while()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XFunction(), XPoster, catch(), if(), Run()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), HttpResponseMessage(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, if(), InvalidOperationException(), Validate(), catch(), CredentialsStartupValidator(), XPoster.Credentials

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, Validate(), nameof(), if(), XPoster.Models

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), if(), DryRunSender()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.33
Nodes (6): FeedOrchestratorFeedUrlProviderTests.cs, SetupHappyPathProviders(), new(), FeedOrchestratorFeedUrlProviderTests(), CreateOrchestrator(), BuildContext()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, TimeProviderTests, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), XPoster.Tests.Providers

### Community 102 - "Entity (Community 102)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, ScheduledOrchestrationProfile(), GetProfiles(), XPoster.Providers, DryRunSlotProfileProvider()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, Validate(), if(), nameof(), XPoster.Models

### Community 100 - "Entity (Community 100)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, FacebookCredentialsValidator, Validate(), if()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, DeleteAsync(), XPoster.Contracts, UploadAsync()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, Validate(), nameof(), if(), XPoster.Models

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSenderTests(), IgSender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender_ImplementsISender()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, JsonResponse(), HttpClient(), MakeDownloadClient(), MakeNoOpClient(), var()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, if(), Validate(), XPoster.Credentials, InstagramCredentialsValidator

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), IMetaPublishingService, GetContainerStatusAsync(), XPoster.Contracts

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, if(), Validate(), XPoster.Models, nameof()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 116 - "Entity (Community 116)"
Cohesion: 0.40
Nodes (5): FeedService.cs, XPoster.Services, catch(), GetFeedsAsync(), Exception()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, ValidateConnectivity(), XPoster.Models, if()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), Process(), MaskUrlTelemetryProcessor()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, XPoster.Tests.Helpers, CreateValidJpeg(), CreateValidPng()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), GetReplacements(), XPoster.Providers

### Community 138 - "Entity (Community 138)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, PromptRequest, XPoster.Models

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), Validate(), XPoster.Credentials

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderOptions, IAiProviderSection, XPoster.Contracts

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, XPoster.Providers, ScheduledOrchestrationProfile(), GetProfiles()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Providers, LocalOverrideTimeProvider()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), GetFeedUrls(), XPoster.Providers

### Community 126 - "Entity (Community 126)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, GetFeedUrls(), IFeedUrlProvider, XPoster.Contracts

### Community 124 - "Entity (Community 124)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, OrchestratorFactory(), InvalidOperationException(), CreateOrchestratorInstance(), if()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), ICredentialsStartupValidator, XPoster.Contracts

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, XPoster.Tests.Models, ValidOptions()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, GenerateImageAsync(), XPoster.Contracts

### Community 132 - "Entity (Community 132)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, ITagReplacementService, XPoster.Contracts, Apply()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 134 - "Entity (Community 134)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, GenerateTextAsync(), XPoster.Contracts

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), XPoster.Contracts, ISlotProfileProvider

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), GenerateTextAsync(), if(), XPoster.Services

### Community 127 - "Entity (Community 127)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, ITimeProvider, GetCurrentTime(), XPoster.Contracts

### Community 130 - "Entity (Community 130)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetChatCompletionsEndpoint(), OpenAiService(), if(), GetImageGenerationEndpoint()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, PowerLawOrchestrator(), XPoster.Orchestrators, if()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, GetCurrentTime(), XPoster.Providers, TimeProvider

### Community 114 - "Entity (Community 114)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, GenerateTextAsync(), if(), var(), XPoster.Services

### Community 164 - "Entity (Community 164)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 165 - "Entity (Community 165)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 153 - "Entity (Community 153)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 145 - "Entity (Community 145)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 146 - "Entity (Community 146)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddResilientHttpClient(), AddHttpClients(), XPoster.Extensions

### Community 152 - "Entity (Community 152)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 148 - "Entity (Community 148)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), DeepSeekService(), GetChatCompletionsEndpoint()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 149 - "Entity (Community 149)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, foreach(), ValidateOptions(), resolve()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 151 - "Entity (Community 151)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Orchestrators, BaseOrchestrator(), PostAsync()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.83
Nodes (4): FeedPromptOptions.cs, FeedPromptOptions.cs, GetStep(), XPoster.Models

### Community 143 - "Entity (Community 143)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 154 - "Entity (Community 154)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, while(), GetChatCompletionsEndpoint(), PerplexityService()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterSenderPlugins()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 155 - "Entity (Community 155)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), XPoster.Models, foreach()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 160 - "Entity (Community 160)"
Cohesion: 0.83
Nodes (4): FeedOrchestratorContext.cs, FeedOrchestratorContext.cs, FeedOrchestratorContext, XPoster.Models

### Community 159 - "Entity (Community 159)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (3): PromptRole.cs, XPoster.Models, PromptRole.cs

### Community 176 - "Entity (Community 176)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 177 - "Entity (Community 177)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, params(), BuildFactory()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, InstagramCredentials.cs, InstagramCredentials.cs

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 169 - "Entity (Community 169)"
Cohesion: 1.00
Nodes (3): XPoster.Models, DeepSeekOptions.cs, DeepSeekOptions.cs

### Community 167 - "Entity (Community 167)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 168 - "Entity (Community 168)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 191 - "Entity (Community 191)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 193 - "Entity (Community 193)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 192 - "Entity (Community 192)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 190 - "Entity (Community 190)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, if(), nameof()

### Community 187 - "Entity (Community 187)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 189 - "Entity (Community 189)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 180 - "Entity (Community 180)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 181 - "Entity (Community 181)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 182 - "Entity (Community 182)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 183 - "Entity (Community 183)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 185 - "Entity (Community 185)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, XPoster.Models, PerplexityOptions.cs

### Community 186 - "Entity (Community 186)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PromptStepOptions.cs, PromptStepOptions.cs

### Community 184 - "Entity (Community 184)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 194 - "Entity (Community 194)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

