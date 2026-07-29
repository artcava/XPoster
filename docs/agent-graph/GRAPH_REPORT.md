# Graph Report - XPoster  (2026-07-29)

## Summary
- 1695 nodes · 2877 edges · 198 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests` - 2 edges
2. `LocalOverrideTimeProviderTests` - 2 edges
3. `XPoster.Tests.Providers` - 2 edges
4. `XPoster.Credentials` - 2 edges
5. `XPoster.Models` - 2 edges
6. `XPoster.Models` - 2 edges
7. `XPoster.Models` - 2 edges
8. `XPoster.Contracts` - 2 edges
9. `XPoster.Models` - 2 edges
10. `XPoster.Models` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_WhenStatusIs429_ReturnsEmptyArray(), ParseImageResponseAsync_WhenStatusIs429_LogsWarning(), ParseImageResponseAsync_WhenMalformedJson_ReturnsEmptyArray(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenEmptyChoices_LogsWarningWithProviderName(), ParseChatCompletionResponseAsync_WhenContentIsWhitespaceOnly_ReturnsTrueAndEmpty() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): FeedOrchestratorTests.cs, FeedOrchestratorTests.cs, OrchestrateAsync_UsesFeedUrls_FromInjectedContext(), OrchestrateAsync_ThirdSender_ReusesUpdatedPreviousSummary_WhenItFitsThirdLimit(), OrchestrateAsync_TwoSlots_ReceiveIndependentFeedUrlsAndPrompts(), OrchestrateAsync_Should_PassNullInputTextLabel_ToPromptRequest(), OrchestrateAsync_Should_CreateMessageWithImage_WhenFeedsAreFound(), OrchestrateAsync_Should_CallTagReplacementProvider_ExactlyOnce_WhenOrchestrationSucceeds() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateTextAsync_RequestBodyContainsModelFromOptions(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyByteArray(), GenerateTextAsync_PostsToChatCompletionsEndpoint(), BuildPromptRequest(), AzureFoundryServiceTests, BuildImagePromptRequest() (+33 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, XPoster.Tests.Services, OpenAiServiceTests, OpenAiService(), GenerateImageAsync_WhenHttpRequestExceptionThrown_LogsError(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), AiServiceHelperImageTests, XPoster.Tests.Services, static(), Parse_FalAi_ValidUrl_ReturnsBytes() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.13
Nodes (30): OrchestratorFactoryTests.cs, OrchestratorFactoryTests.cs, Resolve_Should_NotRequestImageProvider_WhenProfileHasNoImageProvider(), OrchestratorFactoryTests(), PowerLawOrchestrator_SupportedPlatforms_ContainsXAndLinkedIn(), PowerLawProfile(), Resolve_Should_ResolveXSender_ForPowerLawOrchestrator(), Resolve_Should_ResolveIgSender_WhenProfileUsesInstagram() (+22 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, new(), DeepSeekOptionsExtensionsTests, ConfigurationBuilder(), FalAiOptionsExtensionsTests, SectionName_IsDeepSeek(), OptionsExtensionsTests (+21 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GenerateTextAsync_WhenMaxOutputLengthIsNull_CallsApiOnce(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GenerateTextAsync_WhenInputTextLabelIsNull_FallsBackToDefaultLabel(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), GenerateTextAsync_UsesCustomInputTextLabel_InUserPromptSubstitution() (+20 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, SendAsync_TextOnly_WhenResponseHasNullId_ReturnsFalse(), SendAsync_WhenPhotoEndpointReturns503_ReturnsFalseAndDeletesBlob(), SendAsync_TextOnly_WhenResponseMissingId_ReturnsFalse(), SendAsync_WhenHttpClientThrows_ReturnsFalse(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), BuildSender() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, SummaryRequest(), XPoster.Tests.Services, GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent(), GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsBadGateway_ReturnsEmptyString() (+17 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(), SendAsync_ValidTextPost_CatchesTwitterException_ReturnsFalse(), SendAsync_WhitespaceContent_ReturnsFalse(), SendAsync_WhenTwitterContextThrows_ReturnsFalse(), SendAsync_PostWithImage_CatchesTwitterException_ReturnsFalse(), Platform_ReturnsX() (+13 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.20
Nodes (19): FeedPromptOptionsTests.cs, FeedPromptOptionsTests.cs, XPoster.Tests.Models, GetStep_MissingRole_ThrowsInvalidOperationException(), MakeFullOptions(), GetStep_ReturnsStepWithExpectedTemplates(), MakeStep(), GetStep_EmptySteps_ThrowsInvalidOperationException() (+11 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, OpenAiOptions_ApiKeyAndEndpoint_AccessibleThroughAbstraction(), FalAiOptions_ModelCatalog_ExposesImageOnly(), ModelCatalog_EmptyModelName_NotExposedAsSupported(), FalAiOptions_NumInferenceSteps_RemainsOnConcreteClass(), ModelCatalog_UnsupportedCapability_GetRequired_Throws(), OpenAiOptions_ModelCatalog_ExposesTextAndImage() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildRequest(), GetRole(), return(), XPoster.Tests.Services, GetContent(), BuildChatPayload_ForwardsTemperature() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, NormalizeImage_WhenCodecIsNull_ReturnsNull(), NormalizeImage_WithInvalidBytes_ReturnsNull(), NormalizeImage_WhenJpegIsAlreadyValid_ReturnsOriginalBytes(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WhenPngDecodesToNull_ReturnsNull(), Uri() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, FeedService(), BuildFactory(), FakeHttpMessageHandler(), BuildRssXml(), BuildService(), GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml() (+10 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), PublishContainerAsync_WhenRateLimited_Throws(), PublishContainerAsync_WhenOk_ReturnsPublishId(), PublishContainerAsync_WhenIdIsNull_ReturnsEmptyString(), PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException() (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), PromptRequestTests, PromptRequest_ValueEquality_SameValues_AreEqual(), XPoster.Tests.Models, ImagePromptRequest_InheritsFrom_PromptRequest(), ImagePromptRequest_BaseProperties_AreAccessible() (+9 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.23
Nodes (17): PromptStepOptionsTests.cs, PromptStepOptionsTests.cs, PromptStepOptions_ValueEquality_SameValues_AreEqual(), PromptStepOptions_WithExpression_PreservesUnchangedProperties(), XPoster.Tests.Models, PromptStepOptionsTests, PromptStepOptions_ValueEquality_DifferentOptionals_AreNotEqual(), PromptStepOptions_OptionalProperties_DefaultToNull() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending(), SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), UpdateStatusAsync_CanMoveEntryBackToPending(), SaveAsync_WithValidInputs_StoresPendingEntry(), UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException() (+8 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError(), SendAsync_WhenBlobUploadFails_ReturnsFalse(), Uri(), SendAsync_WhenImageUploadNotImplemented_ReturnsFalseAndLogsError(), SendAsync_WhenNoImage_ReturnsFalseWithoutCallingApi() (+7 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.26
Nodes (15): DefaultSlotProfileProviderTests.cs, DefaultSlotProfileProviderTests.cs, GetProfiles_Should_ReturnWellFormedProfiles(), FeedOrchestratorSlot_Should_HaveAtLeastOneSender(), GetProfiles_Should_NotContainDryRunSlot(), FeedOrchestratorSlot_Should_HaveDistinctTextAndImageProviders(), FeedOrchestratorSlot_Should_HaveImageProviderConfigured(), FeedOrchestratorSlot_Should_HaveTextProviderConfigured() (+7 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), DeleteAsync_WhenBlobExists_DeletesSuccessfully(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), DeleteAsync_WithNullBlobName_ThrowsArgumentException() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, XPoster.Tests.Extensions, AddAiProviderOptions_RegistersAllFiveOptionTypes(), ConfigurationBuilder(), AddAiProviderOptions_ReturnsSameServiceCollection(), AddAiProviderOptions_RegistersAllFiveValidators(), BuildAllProvidersConfig() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.13
Nodes (15): DryRunSenderTests.cs, DryRunSender_ImplementsISender(), Constructor_WithNullConfiguration_ThrowsArgumentNullException(), ConfigurationBuilder(), BuildConfig(), DryRunSender(), ValidPost(), SendAsync_WhenKeyMissing_ReturnsFalse() (+7 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.26
Nodes (15): PromptRoleTests.cs, PromptRoleTests.cs, PromptRole_DefinedMember_IsDefined(), PromptRole_BackingValue_IsStable(), PromptRole_UsedAsDictionaryKey_LookupSucceeds(), PromptRoleTests, XPoster.Tests.Models, PromptRole_ParseFromStringIgnoreCase_ReturnsCorrectMember() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_SetAllFields_WhenBothProvidersSupplied(), Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_AllowDifferentProvidersPerCapability_SplitProviderSlot(), Constructor_Should_PreserveHour_ForBoundaryValues(), XPoster.Tests.Models, Constructor_Should_SetTextProvider_And_NullImageProvider_WhenOnlyTextProviderSupplied() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenFacebookUrlHasOnlyAccessToken_TokenIsMasked(), Initialize_WhenFacebookUrlHasNoQueryString_DataUnchanged(), Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), Initialize_WhenHttpDependencyNotFacebook_DoesNotModifyData(), Initialize_WhenFacebookUrlHasNoAccessToken_DataUnchanged() (+7 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction(), if(), PollPendingContainersAsync(), Run(), TryDeleteBlobAsync(), XPoster (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Choice_CanBeCreated_WithMessage(), AIResponse_CanBeCreated_WithChoices(), OpenAIImageResponse_CanBeCreated_WithData(), Post_CanBeCreated_WithRequiredContent(), ImageData_CanBeCreated_WithUrl(), Message_CanBeCreated_WithContent() (+6 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildCreds(), BuildSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn() (+5 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProvider(), LocalOverrideTimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_ValidResponse_ReturnsImageBytes(), FalImageJson(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests, XPoster.Tests.Models, Validate_WhitespaceModelId_Fails(), Validate_BothRequiredFieldsMissing_ReportsBothFailures(), Validate_ImageModelNameWithAllowedSpecialChars_Succeeds(), Validate_MissingApiKey_Fails() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, Supports_ReturnsFalseForMissingModelClass(), Supports_ReturnsTrueForRegisteredModelClass(), TryGet_ReturnsFalseAndNullModelName_WhenNotSupported(), XPoster.Tests.Models, TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported(), Constructor_NullDictionary_Throws() (+5 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, AzureFoundryService(), GenerateImageAsync(), XPoster.Services, GenerateTextAsync(), GetChatCompletionsEndpoint(), var() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, Platform_ReturnsLinkedIn(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse() (+4 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), CreateSut(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenMultiplePendingContainers_ProcessesAll(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp() (+4 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.32
Nodes (12): PowerLawOrchestratorTests.cs, PowerLawOrchestratorTests.cs, CreateOrchestrator(), XPoster.Tests.Orchestrators, GenerateAsync_Should_CreateCorrectMessage_WithActualValue(), GenerateAsync_Should_HandleCryptoServiceFailure_Gracefully(), PowerLawOrchestratorTests(), new() (+4 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), GetReplacements_Should_ReturnReadOnlyDictionary(), XPoster.Tests.Providers, GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured(), Constructor_Should_Throw_When_OptionsIsNull() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.17
Nodes (12): DryRunSenderTests.cs, SendAsync_WhenProbeKeyMissing_LogsError(), SendAsync_WhenProbeKeyPresent_LogsPostContent(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_WithNullPost_LogsWarning(), Platform_ReturnsDryRun(), Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_ReturnsIntMaxValue() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_RequestUsesImageQuantityFromRequest(), FalAiImageService(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, new(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), Constructor_WithNullLogger_ThrowsArgumentNullException(), BuildSender(), BuildCreds(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException() (+3 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly() (+3 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.35
Nodes (11): ConfigurationFeedUrlProviderTests.cs, ConfigurationFeedUrlProviderTests.cs, XPoster.Tests.Providers, ConfigurationFeedUrlProvider(), GetFeedUrls_Should_ReturnEmptyList_When_UrlsPropertyIsNull(), GetFeedUrls_Should_ReturnUrlsInOrder_When_MultipleUrlsConfigured(), GetFeedUrls_Should_ReturnReadOnlyList(), ConfigurationFeedUrlProviderTests (+3 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), BuildSender(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), InSenderResilienceTests, InSender() (+3 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_DoNothing_When_GeneratorIsDisabled(), XFunctionTests() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), BuildCreds(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SendIt_IsAlwaysFalse(), Name_IsNoOrchestrator(), OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests, Build(), SupportedPlatforms_IsEmpty() (+2 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, PublishTextOnlyAsync(), PublishPhotoAsync(), SendAsync(), XPoster.SenderPlugins, if(), catch() (+2 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests, ValidOptions(), Validate_WithValidOptions_ReturnsSuccess(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed() (+2 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyImageArray_ReturnsFalse(), BuildSender(), IgSenderSendAsyncTests, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), SendAsync_WithNoImage_ReturnsFalse() (+2 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.38
Nodes (10): XSenderResilienceTests.cs, XSenderResilienceTests.cs, XSenderResilienceTests, SendAsync_WhenMediaTweetFails_ReturnsFalseAndLogsError(), XSender(), XPoster.Tests.SenderPlugins, SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning(), SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning() (+2 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, XPoster.Services, GetContainerStatusAsync(), PublishContainerAsync(), HttpRequestException(), if(), MetaPublishingService() (+2 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), InvalidImageBytes(), BuildFactory(), FbSenderImageFlowTests, HttpRequestException(), BuildCreds(), XPoster.Tests.SenderPlugins (+1 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, if(), TryGet(), XPoster.Models, InvalidOperationException(), Supports(), AiModelCatalog() (+1 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, XPoster.Tests.Integration, params(), BuildSequenceHandler(), BuildDelayedHandler(), BuildProviderWithHandler(), HttpResponseMessage() (+1 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_CanCreateAllExpectedNamedClients(), AddHttpClients_RegistersIHttpClientFactory(), foreach(), HttpClientExtensionsTests (+1 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.42
Nodes (9): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithValidPost_WithImage_CatchesNetworkException_ReturnsFalse(), XPoster.Tests.SenderPlugins, XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_NoImage_CatchesNetworkException_ReturnsFalse() (+1 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_DefaultPublishDateIsMinValue(), XPoster.Tests.Models, RSSFeed_CanSetPublishDate(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedTests (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, generatePayLoad(), catch(), using(), SendAsync(), InvalidOperationException(), Exception() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): FeedOrchestrator.cs, FeedOrchestrator.cs, foreach(), XPoster.Orchestrators, if(), catch(), BuildPromptRequest(), AcquireFeedContentAsync() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, XPoster.Tests.Services, GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), CryptoServiceTests, CryptoService(), MakeService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet(), XPoster.Tests.Orchestrators (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), PendingContainer(), CreateTimerInfo(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), FbSenderResilienceTests, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), HttpResponseMessage() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, catch(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Facebook_OnRetry_LogEntryIsEmitted(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ParseImageResponseAsync(), ExtractAzureFoundryBytesAsync(), LogAndReturnEmpty(), ExtractOpenAiBytes(), ExtractFalAiBytesAsync(), BuildChatPayload(), XPoster.Services

### Community 71 - "Entity (Community 71)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionMatchesEnumName(), GetLabel_DescriptionDiffersFromEnumName(), AiProviderExtensionsTests, XPoster.Tests.Contracts, GetLabel_UnknownProvider_ReturnsFallbackToString(), GetLabel_KnownProvider_ReturnsDescriptionAttributeValue()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, Dispose(), CreateLogger(), CaptureLogger(), CaptureLoggerProvider(), IsEnabled(), XPoster.Tests.Integration

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, DeleteAsync(), XPoster.Services, BlobStorageService(), if(), BlobUploadResult(), UploadAsync()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_DispatchesEachPostToAlignedSender(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), XPoster.Tests.Models, DeepSeekOptionsValidatorTests

### Community 75 - "Entity (Community 75)"
Cohesion: 0.25
Nodes (8): FeedOrchestratorFeedUrlProviderTests.cs, XPoster.Tests.Providers, OrchestrateAsync_Should_AggregateFeeds_From_All_Urls(), OrchestrateAsync_Should_PassSenderMessageMaxLength_As_MaxOutputLength_In_SummaryRequest(), OrchestrateAsync_Should_ReturnEmpty_And_DisableSendIt_When_ContextHasNoFeedUrls(), OrchestrateAsync_Should_CallGetFeedsAsync_For_Each_Url(), OrchestrateAsync_TwoSlots_Should_UseDifferentFeedUrls_Independently(), OrchestrateAsync_Should_CallGetFeedsAsync_With_Correct_Urls()

### Community 68 - "Entity (Community 68)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, XPoster.Services, GenerateImageAsync(), if(), GetImageGenerationEndpoint(), catch(), FalAiImageService()

### Community 67 - "Entity (Community 67)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), PostTests, XPoster.Tests.Models, Post_EmptyContent_IsAllowed(), Firm_IsNotNullOrEmpty()

### Community 70 - "Entity (Community 70)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests(), XPoster.Tests.SenderPlugins, SendAsync_WithWhiteSpaceContent_ReturnsFalse()

### Community 69 - "Entity (Community 69)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, ImageData, XPoster.Models, AIResponse, Message, OpenAIImageResponse, Choice

### Community 87 - "Entity (Community 87)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, if(), IgSender(), SendAsync(), XPoster.SenderPlugins, catch()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), SaveAsync(), XPoster.Contracts, UpdateStatusAsync(), IContainerStateStore

### Community 85 - "Entity (Community 85)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, var(), GenerateTextAsync(), XPoster.Services, GenerateImageAsync(), while(), catch()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.52
Nodes (7): Program.cs, Program.cs, DryRunSlotProfileProvider(), BlobServiceClient(), if(), Uri(), DefaultAzureCredential()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, SendAsync_WhenUploadThrows_FallsBackToTextOnly(), HttpResponseMessage(), CreateValidJpegBytes(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, XFunction(), XPoster, if(), catch(), Run()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, SaveAsync(), UpdateStatusAsync(), XPoster.Services, GetPendingAsync(), InMemoryContainerStateStore

### Community 80 - "Entity (Community 80)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, foreach(), Apply(), if(), TagReplacementService(), XPoster.Services

### Community 79 - "Entity (Community 79)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests, ValidOptions(), XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, XPoster.Credentials, Validate(), CredentialsStartupValidator(), if(), InvalidOperationException(), catch()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime(), GetCurrentTime_ReturnsUtcTime(), TimeProviderTests

### Community 88 - "Entity (Community 88)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration

### Community 105 - "Entity (Community 105)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, DeleteAsync(), IBlobStorageService, UploadAsync(), XPoster.Contracts

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services

### Community 107 - "Entity (Community 107)"
Cohesion: 0.60
Nodes (6): DryRunSlotProfileProvider.cs, DryRunSlotProfileProvider.cs, XPoster.Providers, GetProfiles(), ScheduledOrchestrationProfile(), DryRunSlotProfileProvider()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), if(), InstagramCredentialsValidator, XPoster.Credentials

### Community 90 - "Entity (Community 90)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), DeepSeekOptionsTests, XPoster.Tests.Models

### Community 91 - "Entity (Community 91)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests, XPoster.Tests.Models, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, PublishContainerAsync(), IMetaPublishingService, GetContainerStatusAsync(), XPoster.Contracts

### Community 99 - "Entity (Community 99)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, XPoster.Models, Validate(), if(), nameof()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, foreach(), Resolve(), XPoster.Orchestrators, typeof(), return()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, XPoster.Models, Validate(), nameof(), if()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, HttpClient(), var(), MakeNoOpClient(), MakeDownloadClient(), JsonResponse()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, Validate(), XPoster.Credentials, if(), FacebookCredentialsValidator

### Community 102 - "Entity (Community 102)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, if(), XPoster.Models, Validate(), nameof()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.33
Nodes (6): FeedOrchestratorFeedUrlProviderTests.cs, SetupHappyPathProviders(), new(), FeedOrchestratorFeedUrlProviderTests(), CreateOrchestrator(), BuildContext()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, DryRunSender(), if(), SendAsync()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), IgSenderTests(), IgSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender_ImplementsISender()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, XPoster.Models, if(), Validate(), nameof()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), OpenAiOptionsValidatorTests, XPoster.Tests.Models

### Community 122 - "Entity (Community 122)"
Cohesion: 0.70
Nodes (5): DefaultSlotProfileProvider.cs, DefaultSlotProfileProvider.cs, ScheduledOrchestrationProfile(), GetProfiles(), XPoster.Providers

### Community 117 - "Entity (Community 117)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, XPoster.Contracts, GetCryptoValue()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.70
Nodes (5): ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider.cs, ConfigurationFeedUrlProvider(), XPoster.Providers, GetFeedUrls()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.70
Nodes (5): IFeedUrlProvider.cs, IFeedUrlProvider.cs, XPoster.Contracts, IFeedUrlProvider, GetFeedUrls()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider(), XPoster.Providers, GetReplacements()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, var(), XPoster.Services, GenerateTextAsync(), if()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, ITagReplacementProvider, XPoster.Contracts, GetReplacements()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, PostAsync(), XPoster.Contracts

### Community 113 - "Entity (Community 113)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Contracts, SendAsync()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, IOrchestratorFactory, Resolve()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, GenerateTextAsync(), XPoster.Services, if(), var()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, IFeedService, GetFeedsAsync()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, GenerateImageAsync(), ITextToImageProvider

### Community 109 - "Entity (Community 109)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidPng(), CreateValidJpeg(), XPoster.Tests.Helpers

### Community 127 - "Entity (Community 127)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, XPoster.Contracts, GetProfiles(), ISlotProfileProvider

### Community 123 - "Entity (Community 123)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch(), XPoster.Tests.Integration

### Community 126 - "Entity (Community 126)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), XPoster.Services, GetFeedsAsync(), catch()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, ValidateConnectivity(), if(), XPoster.Models

### Community 134 - "Entity (Community 134)"
Cohesion: 0.70
Nodes (5): PowerLawOrchestrator.cs, PowerLawOrchestrator.cs, XPoster.Orchestrators, PowerLawOrchestrator(), if()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, XPoster.Models, ImagePromptRequest, PromptRequest

### Community 138 - "Entity (Community 138)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), XPoster.Credentials, Validate()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Providers, GetCurrentTime()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), LocalOverrideTimeProvider(), XPoster.Providers

### Community 133 - "Entity (Community 133)"
Cohesion: 0.40
Nodes (5): OrchestratorFactory.cs, InvalidOperationException(), if(), CreateOrchestratorInstance(), OrchestratorFactory()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, Validate(), XPoster.Contracts, ICredentialsStartupValidator

### Community 129 - "Entity (Community 129)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, OpenAiService(), if(), GetImageGenerationEndpoint(), GetChatCompletionsEndpoint()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), if(), Process()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), XPoster.Contracts, ITagReplacementService

### Community 132 - "Entity (Community 132)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, ITextToTextProvider, GenerateTextAsync()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.83
Nodes (4): FeedOrchestratorContext.cs, FeedOrchestratorContext.cs, FeedOrchestratorContext, XPoster.Models

### Community 168 - "Entity (Community 168)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 156 - "Entity (Community 156)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, foreach(), Validate(), XPoster.Models

### Community 148 - "Entity (Community 148)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, DeepSeekService(), GetChatCompletionsEndpoint(), while()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for(), StringContent()

### Community 155 - "Entity (Community 155)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, PostAsync(), XPoster.Orchestrators, BaseOrchestrator()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.83
Nodes (4): FalAiOptionsExtensions.cs, FalAiOptionsExtensions.cs, AddFalAiOptions(), XPoster.Models

### Community 152 - "Entity (Community 152)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, foreach(), ValidateOptions(), resolve()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), AddResilientHttpClient(), XPoster.Extensions

### Community 154 - "Entity (Community 154)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, if(), return(), catch()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 147 - "Entity (Community 147)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, while(), GetChatCompletionsEndpoint(), PerplexityService()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.83
Nodes (4): FeedPromptOptions.cs, FeedPromptOptions.cs, GetStep(), XPoster.Models

### Community 143 - "Entity (Community 143)"
Cohesion: 0.50
Nodes (4): ResilienceTestHelpers.cs, BuildSequenceHandler(), var(), XPoster.Tests.Helpers

### Community 144 - "Entity (Community 144)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 145 - "Entity (Community 145)"
Cohesion: 0.83
Nodes (4): OpenAiOptionsExtensions.cs, OpenAiOptionsExtensions.cs, AddOpenAiOptions(), XPoster.Models

### Community 146 - "Entity (Community 146)"
Cohesion: 0.50
Nodes (4): XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins

### Community 157 - "Entity (Community 157)"
Cohesion: 0.83
Nodes (4): AzureFoundryOptionsExtensions.cs, AzureFoundryOptionsExtensions.cs, XPoster.Models, AddAzureFoundryOptions()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, XPoster.Orchestrators, NoOrchestrator()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.83
Nodes (4): PerplexityOptionsExtensions.cs, PerplexityOptionsExtensions.cs, XPoster.Models, AddPerplexityOptions()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 158 - "Entity (Community 158)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 160 - "Entity (Community 160)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 163 - "Entity (Community 163)"
Cohesion: 0.83
Nodes (4): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderOptions, XPoster.Contracts

### Community 162 - "Entity (Community 162)"
Cohesion: 0.83
Nodes (4): DeepSeekOptionsExtensions.cs, DeepSeekOptionsExtensions.cs, AddDeepSeekOptions(), XPoster.Models

### Community 139 - "Entity (Community 139)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 181 - "Entity (Community 181)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 179 - "Entity (Community 179)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.67
Nodes (3): XSender.cs, if(), XSender()

### Community 180 - "Entity (Community 180)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 177 - "Entity (Community 177)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 174 - "Entity (Community 174)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PromptRole.cs, PromptRole.cs

### Community 176 - "Entity (Community 176)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 169 - "Entity (Community 169)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 175 - "Entity (Community 175)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 173 - "Entity (Community 173)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, LinkedInCredentials.cs, XPoster.Credentials

### Community 172 - "Entity (Community 172)"
Cohesion: 1.00
Nodes (3): XPoster.Models, FalAiOptions.cs, FalAiOptions.cs

### Community 170 - "Entity (Community 170)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 171 - "Entity (Community 171)"
Cohesion: 1.00
Nodes (3): FeedOptions.cs, XPoster.Models, FeedOptions.cs

### Community 194 - "Entity (Community 194)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiProvider.cs, AiProvider.cs

### Community 196 - "Entity (Community 196)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 195 - "Entity (Community 195)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 193 - "Entity (Community 193)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, SenderPlatform.cs, SenderPlatform.cs

### Community 191 - "Entity (Community 191)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 182 - "Entity (Community 182)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 190 - "Entity (Community 190)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 192 - "Entity (Community 192)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 184 - "Entity (Community 184)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, OpenAiOptions.cs, XPoster.Models

### Community 185 - "Entity (Community 185)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, PromptStepOptions.cs, XPoster.Models

### Community 186 - "Entity (Community 186)"
Cohesion: 0.67
Nodes (3): ResilienceTestHelpers.cs, BuildFactory(), params()

### Community 188 - "Entity (Community 188)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, AiModelClass.cs, AiModelClass.cs

### Community 189 - "Entity (Community 189)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, Validate(), XPoster.Credentials

### Community 197 - "Entity (Community 197)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

