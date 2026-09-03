# Graph Report - XPoster  (2026-09-03)

## Summary
- 1684 nodes · 2867 edges · 195 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Contracts` - 2 edges
2. `IContainerStateStore` - 2 edges
3. `XPoster.Services` - 2 edges
4. `XPoster.Credentials` - 2 edges
5. `XPoster.Orchestrators` - 2 edges
6. `XPoster.Tests.SenderPlugins` - 2 edges
7. `XSenderResilienceTests` - 2 edges
8. `FbSenderImageFlowTests` - 2 edges
9. `XPoster.Tests.SenderPlugins` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AiServiceHelperTests, OpenAiB64Json(), ParseChatCompletionResponseAsync_WhenChoicesIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseChatCompletionResponseAsync_WhenValidResponse_ReturnsTrueAndTrimmedContent() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_ReturnsNullEntry_WhenReSummarisationFails(), OrchestrateAsync_GeneratesBaseSummaryAtPrimaryMaxLength(), OrchestrateAsync_ReSummarisesViaAI_WhenBaseSummaryExceedsSecondaryLimit(), OrchestrateAsync_Should_ReturnNull_When_SummaryGenerationFails(), OrchestrateAsync_Should_ReturnNull_When_SenderIsNull(), OrchestrateAsync_Should_CallTagReplacementProvider_ExactlyOnce_WhenOrchestrationSucceeds() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, XPoster.Tests.Services, MakeHandlerMock(), if(), GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_ReturnsContent(), GenerateTextAsync_WhenUsedAsImagePromptDerivationStep_AndChoicesNull_ReturnsEmptyString(), HttpResponseMessage() (+33 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, BuildService(), BuildPromptRequest(), BuildImagePromptRequest(), GenerateTextAsync_UsesSystemPromptTemplateFromRequest(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi(), GenerateTextAsync_ReplacesInputTextLabelInUserPromptTemplate() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_OpenAi_EmptyB64Value_ReturnsEmpty(), Parse_FalAi_ValidUrl_ReturnsBytes(), Parse_NonSuccessStatus_ReturnsEmpty(), Parse_MalformedJson_ReturnsEmpty(), return(), static(), XPoster.Tests.Services (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, SectionName_IsOpenAI(), XPoster.Tests.Models, SectionName_IsPerplexity(), OptionsExtensionsTests, SectionName_IsAzureFoundry(), PerplexityOptionsExtensionsTests (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, ChatCompletionJson(), BuildImagePromptRequest(), BuildSummaryRequest(), BuildService(), PerplexityService(), GenerateTextAsync_WhenTextRemainsLongAfterMaxRetries_ReturnsLastApiContent() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, BuildCreds(), SendAsync_WithCaptionExceedingMaxLength_TruncatesAndPublishes(), XPoster.Tests.SenderPlugins, FbSenderTests(), Constructor_WithNullLogger_ThrowsArgumentNullException(), FbSender() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenChoicesIsNull_ForImagePromptRole_ReturnsEmptyString(), GenerateTextAsync_WhenResponseFitsWithinMaxOutputLength_ReturnsSingleCallResult(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetryRegardlessOfLength(), BuildService(), GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.09
Nodes (22): OrchestratorFactoryTests.cs, Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ResolveXSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveXSender_WhenProfileUsesX(), Resolve_Should_ReturnCorrectOrchestratorType_ForGivenSenderProfile(), Resolve_Should_ResolveInSender_WhenProfileUsesLinkedIn(), Resolve_Should_ResolveFbSender_WhenProfileUsesFacebook(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram() (+14 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_ValidPost_TriesTwitterAndReturnsFalse(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhenTwitterContextThrows_ReturnsFalse(), SendAsync_EmptyContent_ReturnsFalse(), Constructor_WithNullLogger_ThrowsArgumentNullException() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.20
Nodes (19): FeedPromptOptionsTests.cs, FeedPromptOptionsTests.cs, GetStep_DuplicateRole_ThrowsInvalidOperationException(), FeedPromptOptions_ValueEquality_DifferentSteps_AreNotEqual(), FeedPromptOptions_ValueEquality_SameSteps_AreEqual(), FeedPromptOptionsTests, FeedPromptOptions_WithExpression_PreservesStepsReference(), MakeStep() (+11 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, GetFeedsAsync_FiltersOutItemsWithNoKeywordMatch(), FeedService(), foreach(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsOutsideDateRange(), FeedServiceTests (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WhenCodecIsNull_ReturnsNull(), NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), NormalizeImage_WithInvalidBytes_ReturnsNull(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull(), IgSender() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests, BuildChatPayload_ForwardsMaxTokenBudget(), BuildChatPayload_FirstMessageRoleIsSystem(), BuildChatPayload_SystemMessage_NoPlaceholder_IsUnchanged(), BuildChatPayload_InterpolatesMaxCharsInSystemMessage(), BuildChatPayload_SubstitutesCustomLabelInUserMessage() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, ModelCatalog_UnsupportedCapability_GetRequired_Throws(), FalAiOptions_ImplementsIAiProviderOptions(), ModelCatalog_EmptyModelName_NotExposedAsSupported(), FalAiOptions_NumInferenceSteps_RemainsOnConcreteClass(), FalAiOptions_ModelCatalog_ExposesImageOnly(), PerplexityOptions_ModelCatalog_ExposesTextOnly() (+10 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, XPoster.Tests.Services, PublishContainerAsync_WhenOk_ReturnsPublishId(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), PublishContainerAsync_WhenRateLimited_Throws(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException() (+9 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.23
Nodes (17): PromptStepOptionsTests.cs, PromptStepOptionsTests.cs, PromptStepOptions_ImageGenerationStep_ImageProperties_AreIndependent(), PromptStepOptions_AllRoles_CanBeConstructed(), PromptStepOptions_SummaryStep_MaxOutputLength_IsNullByConvention(), PromptStepOptions_NonImageSteps_ImageProperties_AreNull(), PromptStepOptions_OptionalProperties_AreSetCorrectly(), PromptStepOptions_OptionalProperties_DefaultToNull() (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_ValueEquality_SameValues_AreEqual(), XPoster.Tests.Models, PromptRequestTests, PromptRequest_Temperature_AcceptsZeroAndOne(), ImagePromptRequest_ValueEquality_SameValues_AreEqual(), PromptRequest_OptionalProperties_AreSetCorrectly() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), InMemoryContainerStateStoreTests, GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), GetPendingAsync_ReturnsOnlyPendingEntries(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): PromptRoleTests.cs, PromptRoleTests.cs, PromptRole_ParseInvalidName_Throws(), PromptRole_ParseFromString_ReturnsCorrectMember(), PromptRole_HasExactlyThreeMembers(), PromptRole_DefinedMember_IsDefined(), PromptRole_ParseFromStringIgnoreCase_ReturnsCorrectMember(), PromptRole_BackingValue_IsStable() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenTelemetryIsNotDependency_DoesNothing(), Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, DryRunSender(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), BuildConfig(), DryRunSender_ImplementsISender(), ConfigurationBuilder(), ValidPost(), SendAsync_WithNullPost_ReturnsFalse() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied(), Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_SetBothProvidersToNull_WhenNeitherSupplied(), Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_SetImageProvider_And_NullTextProvider_WhenOnlyImageProviderSupplied() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, DeleteAsync_WhenBlobExists_DeletesSuccessfully(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), DeleteAsync_WithNullBlobName_ThrowsArgumentException() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), Uri(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), SendAsync_WhenBlobUploadFails_ReturnsFalse() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, PowerLawSlot_Should_ContainLinkedInAndX(), PowerLawSlot_Should_HaveNullTextAndImageProvider(), XPoster.Tests.Providers, GetProfiles_Should_HaveUniqueHours(), DryRunSlotProfileProvider_DryRunSlot_Should_HaveBothProvidersConfigured(), FeedOrchestratorSlot_Should_ContainLinkedInAndX() (+7 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests, AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection(), AddAiProviderOptions_RegistersAllFiveValidators(), AddAiProviderOptions_RegistersAllFiveOptionTypes(), AddAiProviderOptions_ReturnsSameServiceCollection(), AddAiProviderOptions_DoesNotDuplicateValidatorRegistrations_WhenCalledOnce() (+7 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, ModelsTests, ImageData_CanBeCreated_WithUrl(), Message_CanBeCreated_WithContent(), Choice_CanBeCreated_WithMessage(), AIResponse_CanBeCreated_WithChoices(), Post_CanHold_ImageBytes() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction(), TryDeleteBlobAsync(), HandleFinishedAsync(), HandleTerminalFailureAsync(), switch(), ProcessContainerAsync() (+6 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, BuildService(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), FalImageJson(), FalAiImageServiceTests (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, Supports_ReturnsTrueForRegisteredModelClass(), AiModelCatalogTests, GetRequired_Throws_WhenNotSupported(), Constructor_ExcludesNullOrWhitespaceEntries(), Supports_ReturnsFalseForMissingModelClass(), GetRequired_ReturnsModelName_WhenSupported() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, Constructor_AlwaysEmitsDevOverrideWarning(), BuildProvider(), GetCurrentTime_WhenForceHourIsEmpty_FallsBackToUtcHour(), LocalOverrideTimeProvider(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_MissingModelId_Fails(), Validate_WhitespaceApiKey_Fails(), Validate_ValidOptions_Succeeds(), Validate_WhitespaceModelId_Fails(), XPoster.Tests.Models, ValidOptions() (+5 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), InSender_ImplementsISender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), SendAsync_TextOnly_WithPersonCode_UsesPersonUrn() (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WhenProbeKeyMissing_LogsError(), Platform_ReturnsDryRun(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), SendAsync_DoesNotCallAnyOutboundSocialApi(), BuildSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), DryRunSenderTests() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, GenerateAsync_Should_ReturnNull_When_DateIsBeforeGenesis(), new(), OrchestrateAsync_BroadcastsSamePost_ToAllSenders(), XPoster.Tests.Orchestrators, PowerLawOrchestratorTests(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, GenerateImageAsync(), catch(), AzureFoundryService(), GetChatCompletionsEndpoint(), if(), XPoster.Services (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenCancelledDuringForEach_StopsGracefully() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnReadOnlyDictionary(), ConfigurationTagReplacementProvider(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), ConfigurationTagReplacementProviderTests (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), InSender(), InSenderTests(), Platform_ReturnsLinkedIn(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, FalAiImageService(), MakeRequest(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), MakeHandlerMock(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_Returns429_LogsWarning() (+4 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, Constructor_Should_Throw_When_OptionsIsNull(), ConfigurationFeedUrlProvider(), ConfigurationFeedUrlProviderTests, GetFeedUrls_Should_ReturnEmptyList_When_UrlsListIsEmpty(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), XPoster.Tests.Providers (+3 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AiProviderServiceCollectionExtensionsTests, XPoster.Tests.Extensions, AddXPosterAiProviders_ReturnsSameServiceCollection(), AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_InitializesCorrectly(), BuildSender(), BuildCreds(), Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), XPoster.Tests.SenderPlugins, new() (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, InSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.18
Nodes (11): OrchestratorFactoryTests.cs, FeedOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), CreateFactory(), DryRunSlotProfileProvider_Should_AppendDryRunProfile_ToInnerProviderProfiles(), new(), typeof(), NoOrchestrator_SupportedPlatforms_IsEmpty(), Resolve_Should_NotRequestTextProvider_WhenProfileHasNoTextProvider() (+3 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, catch(), GetContainerStatusAsync(), XPoster.Services, if(), MetaPublishingService(), HttpRequestException() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, BuildSender(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XSenderResilienceTests, XSender(), SendAsync_WhenTextTweetFails_ReturnsFalseAndLogsError() (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, if(), PublishTextOnlyAsync(), PublishPhotoAsync(), SendAsync(), XPoster.SenderPlugins, HandleResponseAsync() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests, Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), ValidOptions(), Validate_WithValidOptions_ReturnsSuccess() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), FbSenderSendAsyncTests, BuildCreds(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), SendIt_Set_ThrowsNotImplementedException(), XPoster.Tests.Orchestrators, OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests, Build() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), XPoster.Tests (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), IgSenderSendAsyncTests, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), SendAsync_WithEmptyImageArray_ReturnsFalse(), BuildSender(), IgSender() (+2 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), PendingContainer(), CreateTimerInfo(), RunAsync_WhenCancelled_StopsGracefully() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenPhotoPublishThrows_FallsBackToTextOnly(), XPoster.Tests.SenderPlugins, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), HttpRequestException(), BuildCreds(), InvalidImageBytes(), FbSenderImageFlowTests (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_ReturnsFalse_WhenOneSenderFails(), XPoster.Tests.Orchestrators, PostAsync_SkipsNullPost_ReturnsFalse() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, Supports(), XPoster.Models, TryGet(), GetRequired(), AiModelCatalog(), InvalidOperationException() (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_CanCreateAllExpectedNamedClients(), foreach(), HttpClientExtensionsTests, XPoster.Tests.Extensions (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), FbSenderResilienceTests (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), catch() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, AcquireFeedContentAsync(), catch(), XPoster.Orchestrators, if(), foreach(), FeedOrchestrator() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, using(), SendAsync(), Exception(), InvalidOperationException(), generatePayLoad(), ResolveAuthorUrn() (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, XPoster.Tests.Integration, var(), HttpResponseMessage(), BuildSequenceHandler(), BuildDelayedHandler(), BuildProviderWithHandler() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XSenderSendAsyncTests() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, GetCryptoValue_ReturnsZero_AndLogsError_OnException(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), MakeService(), CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_CanCreateWithRequiredProperties(), XPoster.Tests.Models (+1 more)

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, if(), BlobUploadResult(), BlobStorageService(), DeleteAsync(), XPoster.Services, UploadAsync()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.25
Nodes (8): FeedOrchestratorFeedUrlProviderTests.cs, OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ContextHasNoFeedUrls(), OrchestrateAsync_Should_PassSenderMessageMaxLength_As_MaxOutputLength_In_SummaryRequest(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls(), OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), XPoster.Tests.Providers, OrchestrateAsync_TwoSlots_Should_UseDifferentFeedUrls_Independently()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), ValidOptions(), Validate_MissingRequiredProperties_Fails(), XPoster.Tests.Models, Validate_ValidOptions_Succeeds()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Firm_IsNotNullOrEmpty(), Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), PostTests, Post_EmptyContent_IsAllowed(), XPoster.Tests.Models

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, GenerateImageAsync(), catch(), FalAiImageService(), XPoster.Services, if(), GetImageGenerationEndpoint()

### Community 72 - "Entity (Community 72)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, CreateLogger(), Dispose(), IsEnabled(), CaptureLoggerProvider(), CaptureLogger()

### Community 71 - "Entity (Community 71)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), ExtractFalAiBytesAsync(), ParseImageResponseAsync(), XPoster.Services, ExtractOpenAiBytes(), LogAndReturnEmpty(), BuildChatPayload()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_DescriptionDiffersFromEnumName(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionMatchesEnumName(), AiProviderExtensionsTests, XPoster.Tests.Contracts

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, Choice, ImageData, OpenAIImageResponse, XPoster.Models, Message, AIResponse

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, InSenderSendAsyncTests(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalse()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, GenerateImageAsync(), catch(), var(), while(), XPoster.Services, GenerateTextAsync()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, if(), DryRunSlotProfileProvider(), DefaultAzureCredential(), Uri(), BlobServiceClient()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), if(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), HttpResponseMessage()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, XPoster.Contracts, IContainerStateStore, GetPendingAsync(), SaveAsync(), UpdateStatusAsync()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, XPoster.Credentials, InvalidOperationException(), CredentialsStartupValidator(), Validate(), if(), catch()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, TagReplacementService(), XPoster.Services, Apply(), foreach(), if()

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, ValidOptions(), Validate_ValidOptions_Succeeds(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models

### Community 81 - "Entity (Community 81)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, foreach(), catch(), Resolve(), XPoster.Orchestrators, return(), typeof()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XFunction(), catch(), if(), Run(), XPoster

### Community 88 - "Entity (Community 88)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, catch(), if(), IgSender(), SendAsync(), XPoster.SenderPlugins

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, SaveAsync(), InMemoryContainerStateStore, GetPendingAsync(), XPoster.Services, UpdateStatusAsync()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, nameof(), if(), XPoster.Models, Validate()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.33
Nodes (6): FeedOrchestratorFeedUrlProviderTests.cs, SetupHappyPathProviders(), FeedOrchestratorFeedUrlProviderTests(), BuildContext(), CreateOrchestrator(), new()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, if(), XPoster.Models, nameof(), Validate()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, XPoster.Tests.Providers

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, InstagramCredentialsValidator, if(), Validate(), XPoster.Credentials

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, FacebookCredentialsValidator, if(), Validate(), XPoster.Credentials

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), if(), DryRunSender()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), IMetaPublishingService, XPoster.Contracts, GetContainerStatusAsync()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Providers, ScheduledOrchestrationProfile(), GetProfiles(), DryRunSlotProfileProvider()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptionsTests, AzureFoundryOptions_Defaults_AreCorrect()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, DeleteAsync(), UploadAsync(), XPoster.Contracts

### Community 100 - "Entity (Community 100)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender_ImplementsISender(), IgSender(), IgSenderTests(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), XPoster.Tests.Integration

### Community 96 - "Entity (Community 96)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), XPoster.Tests.Services

### Community 97 - "Entity (Community 97)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), HttpClient(), MakeDownloadClient(), JsonResponse()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, Validate(), nameof(), if(), XPoster.Models

### Community 103 - "Entity (Community 103)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_DoesNotExpose_ApiVersionProperty()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, GenerateImageAsync(), XPoster.Contracts

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, if(), XPoster.Orchestrators, PowerLawOrchestrator()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, GetProfiles(), ScheduledOrchestrationProfile(), XPoster.Providers

### Community 126 - "Entity (Community 126)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, PromptRequest, XPoster.Models

### Community 121 - "Entity (Community 121)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, if(), OpenAiService(), GetChatCompletionsEndpoint(), GetImageGenerationEndpoint()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Providers, GetCurrentTime()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, Process(), MaskUrlTelemetryProcessor(), if()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, GetReplacements(), XPoster.Contracts

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), XPoster.Contracts, ITagReplacementService

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderSection, XPoster.Contracts, IAiProviderOptions

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Contracts, ICryptoService

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, GenerateTextAsync(), if(), var(), XPoster.Services

### Community 138 - "Entity (Community 138)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), GetFeedsAsync(), XPoster.Services, catch()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, GenerateTextAsync(), ITextToTextProvider, XPoster.Contracts

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), ITimeProvider, XPoster.Contracts

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), IFeedService, XPoster.Contracts

### Community 131 - "Entity (Community 131)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, GetFeedUrls(), ConfigurationFeedUrlProvider(), XPoster.Providers

### Community 127 - "Entity (Community 127)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, InvalidOperationException(), if(), CreateOrchestratorInstance(), OrchestratorFactory()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, catch(), Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, if(), XPoster.Models, ValidateConnectivity()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Contracts, SendAsync()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), if(), XPoster.Credentials

### Community 132 - "Entity (Community 132)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), XPoster.Providers, GetReplacements()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, XPoster.Services, var(), if(), GenerateTextAsync()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, GetProfiles(), XPoster.Contracts

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, IOrchestratorFactory, XPoster.Contracts, Resolve()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, IFeedUrlProvider, GetFeedUrls()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 152 - "Entity (Community 152)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 148 - "Entity (Community 148)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, BuildSequenceHandler(), var()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 149 - "Entity (Community 149)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 151 - "Entity (Community 151)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, PerplexityService(), while(), GetChatCompletionsEndpoint()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.83
Nodes (4): FeedOrchestratorContext.cs, FeedOrchestratorContext.cs, FeedOrchestratorContext, XPoster.Models

### Community 141 - "Entity (Community 141)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 143 - "Entity (Community 143)"
Cohesion: 0.83
Nodes (4): FeedPromptOptions.cs, FeedPromptOptions.cs, GetStep(), XPoster.Models

### Community 164 - "Entity (Community 164)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), foreach(), XPoster.Models

### Community 165 - "Entity (Community 165)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 154 - "Entity (Community 154)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, GetChatCompletionsEndpoint(), while(), DeepSeekService()

### Community 163 - "Entity (Community 163)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 162 - "Entity (Community 162)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterSenderPlugins()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), resolve(), foreach()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 155 - "Entity (Community 155)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.50
Nodes (4): XSender.cs, XPoster.SenderPlugins, SendAsync(), catch()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 160 - "Entity (Community 160)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 159 - "Entity (Community 159)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 178 - "Entity (Community 178)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 191 - "Entity (Community 191)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 193 - "Entity (Community 193)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 192 - "Entity (Community 192)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 190 - "Entity (Community 190)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 188 - "Entity (Community 188)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 179 - "Entity (Community 179)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 187 - "Entity (Community 187)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 189 - "Entity (Community 189)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 181 - "Entity (Community 181)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 182 - "Entity (Community 182)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, SenderPlatform.cs, XPoster.Contracts

### Community 183 - "Entity (Community 183)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 185 - "Entity (Community 185)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 184 - "Entity (Community 184)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, XPoster.Models, PromptStepOptions.cs

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (3): PromptRole.cs, XPoster.Models, PromptRole.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 1.00
Nodes (3): XPoster.Models, AzureFoundryOptions.cs, AzureFoundryOptions.cs

### Community 177 - "Entity (Community 177)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 173 - "Entity (Community 173)"
Cohesion: 0.67
Nodes (3): XSender.cs, XSender(), if()

### Community 166 - "Entity (Community 166)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, XPoster.Contracts, AiModelClass.cs

### Community 172 - "Entity (Community 172)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 169 - "Entity (Community 169)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 167 - "Entity (Community 167)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 168 - "Entity (Community 168)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 194 - "Entity (Community 194)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

