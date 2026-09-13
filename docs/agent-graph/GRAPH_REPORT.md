# Graph Report - XPoster  (2026-09-13)

## Summary
- 1953 nodes · 3309 edges · 237 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `NoOrchestratorTests` - 2 edges
2. `XPoster.Tests.Models` - 2 edges
3. `AiProviderExtensionsTests` - 2 edges
4. `XPoster.Workflows.Models` - 2 edges
5. `WorkflowContext` - 2 edges
6. `XPoster.Services` - 2 edges
7. `XPoster.SenderPlugins` - 2 edges
8. `XPoster.Tests.Extensions` - 2 edges
9. `XPoster.Services` - 2 edges
10. `IgSenderSendAsyncTests` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, AiServiceHelperTests, ParseChatCompletionResponseAsync_WhenStatusIs429_LogsInformation(), ParseChatCompletionResponseAsync_WhenNonSuccess_LogsProviderNameAndStatusCode(), ParseChatCompletionResponseAsync_WhenResponseBodyIsEmpty_ReturnsFalseAndEmpty(), ParseImageResponseAsync_AzureFoundry_UrlFallback_DownloadFails_ReturnsEmptyArray(), ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, AzureFoundryServiceTests, AzureFoundryService(), BuildService(), BuildImagePromptRequest(), BuildPromptRequest(), ChatCompletionJson() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateTextAsync_WhenOutputFitsWithinMaxOutputLength_ReturnsSingleCallResult(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmpty(), GenerateTextAsync_WhenNoMaxOutputLength_DoesNotRetry(), BuildPromptRequest(), BuildImagePromptRequest(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, BuildConfig(), BuildShortSender(), BuildMaxSender(), MaxSender_Platform_IsDryRunMaxLength(), MaxSender_ImplementsISender(), MaxSender_MessageMaxLength_IsIntMaxValue() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, static(), XPoster.Tests.Services, Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), Parse_AzureFoundry_UrlFallback_DownloadThrows_LogsError(), Parse_AzureFoundry_UrlFallback_ReturnsBytes(), Parse_AzureFoundry_UrlFallback_DownloadThrows_ReturnsEmpty() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, BuildProvider(), DeepSeekOptionsExtensionsTests, ConfigurationBuilder(), AddDeepSeekOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_BindsOptionsFromCorrectSection(), AddAzureFoundryOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, BuildService(), BuildImagePromptRequest(), XPoster.Tests.Services, ChatCompletionJson(), GenerateTextAsync_ImagePromptRole_WhenApiReturns429_ReturnsEmptyString(), foreach() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, return(), NormalizeImage_WithValidJpeg_ReturnsSameBytes(), NormalizeImage_WithValidPng_ReturnsOriginalBytes(), Platform_ReturnsFacebook(), XPoster.Tests.SenderPlugins, SendAsync_WhenPhotoEndpointReturns503_ReturnsFalseAndDeletesBlob() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, GenerateTextAsync_WhenCancellationRequested_ThrowsOperationCanceledException(), GenerateTextAsync_WhenApiReturnsBadGateway_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsValidResponse_ReturnsContent(), GenerateTextAsync_WhenApiReturnsInternalServerError_ReturnsEmptyString(), BuildService(), GenerateTextAsync_UsesSystemAndUserTemplatesFromRequest_NotFromOptions() (+17 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetParameter_DirectCast_String(), GetParameter_ConvertChangeType_IntFromString(), GetParameter_DefaultValue_UsedWhenMissing(), GetParameter_DirectCast_Int(), GetParameter_JsonElement_ToString(), GetParameter_JsonElement_ToBool() (+17 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, XPoster.Tests.Workflows.Engine, return(), WorkflowExecutionEngineTests, static(), Execute_PowerLawChain_AcquireThenBuildThenFanOut_StoresOutputs(), Execute_LinearChain_ExecutesInOrder_AndStoresOutputs(), Execute_NodeFailure_StopsExecution_AndReturnsError() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WithImage_WhenUploadFails_ReturnsFalseAndLogsError(), SendAsync_WhenApiReturns402_ReturnsFalseAndLogsError(), SendAsync_WhenConnectionFails_ReturnsFalseAndLogsError(), SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(), SendAsync_NullPost_ReturnsFalse(), MessageMaxLength_Returns250() (+13 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, Uri(), return(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse(), IgSenderImageFlowTests (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_FirstMessageRoleIsSystem(), AiServiceHelperChatPayloadTests, BuildChatPayload_ForwardsMaxTokenBudget(), BuildChatPayload_InterpolatesMaxCharsInSystemMessage(), BuildChatPayload_ForwardsModelName(), BuildChatPayload_ForwardsTemperature() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenHttpFails(), GetFeedsAsync_ReturnsFeedsFromCache_IfPresent(), new(), SendAsync(), BuildFactory() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, ConcurrentReadWrite_DoesNotThrow(), catch(), SetData_AndGetData_RoundTrip(), HasData_ReturnsFalse_WhenKeyMissing(), GetData_ThrowsOnMissingKey(), GetData_ThrowsOnTypeMismatch() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, ModelCatalog_UnsupportedCapability_GetRequired_Throws(), FalAiOptions_ImplementsIAiProviderOptions(), ModelCatalog_EmptyModelName_NotExposedAsSupported(), FalAiOptions_ModelCatalog_ExposesImageOnly(), FalAiOptions_NumInferenceSteps_RemainsOnConcreteClass(), DeepSeekOptions_ModelCatalog_ExposesTextOnly() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), MetaPublishingService(), GetContainerStatusAsync_WithEmptyCreationId_ThrowsArgumentException(), GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, AddWorkflows_Registers_WorkflowDefinitions_AsKeyedSingletons(), AddWorkflows_Registers_KeyedNodes(), AddWorkflows_ConvertsParameters_ToObjectDictionary(), AddWorkflows_Registers_StepOptionsResolver(), InMemory(), AddWorkflows_WithNoTerminalNode_ThrowsInvalidOperationException() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), XPoster.Tests.Models, PromptRequestTests, PromptRequest_ValueEquality_SameValues_AreEqual(), ImagePromptRequest_ImageProperties_DefaultToNull(), ImagePromptRequest_BaseProperties_AreAccessible() (+9 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), GetPendingAsync_ReturnsOnlyPendingEntries(), GetPendingAsync_WhenStoreIsEmpty_ReturnsEmptyList(), SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), InMemoryContainerStateStoreTests, UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_SkipSlot_WithNoWorkflowKey(), new(), GetProfiles_Should_SkipSlot_WithNoSenders(), GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes(), XPoster.Tests.Providers, GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, TwoTerminals(), Cyclic(), MissingRef(), Linear(), ValidateTerminalNodeContract_TerminalImplementsContract_ReturnsNull(), ValidateStructural_MissingNodeReference_ReturnsError(), ValidateStructural_ValidLinearDag_ReturnsNull() (+8 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, IgSender(), PostWithoutImage(), IgSenderResilienceTests, PostWithImage(), new(), SendAsync_WhenBlobUploadCancelled_ReturnsFalseAndLogsError() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, BuildAllProvidersConfig(), XPoster.Tests.Extensions, ConfigurationBuilder(), AddAiProviderOptions_BindsFalAiOptions_FromCorrectSection(), AddAiProviderOptions_BindsAzureFoundryOptions_FromCorrectSection(), AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenDataIsEmpty_DoesNotThrow(), MaskUrlTelemetryProcessorTests (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_WhenStorageThrows_PropagatesException(), DeleteAsync_WithNullBlobName_ThrowsArgumentException(), UploadAsync_SasUriExpiry_IsApproximately30Minutes(), UploadAsync_WhenContainerDoesNotExist_CreatesItAndUploads(), UploadAsync_WhenBlobClientSucceeds_ReturnsSasUri(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, if(), HandleTerminalFailureAsync(), HandleFinishedAsync(), foreach(), catch(), XPosterContainerPollingFunction() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, RSSFeed_PublishDate_DefaultsToMinValue(), OpenAIImageResponse_CanBeCreated_WithData(), RSSFeed_CanBeCreated_WithAllProperties(), Post_Firm_ContainsExpectedHashtags(), Post_CanHold_ImageBytes(), Post_CanBeCreated_WithRequiredContent() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, XPoster.Tests.Workflows.Nodes, FanOutSendNodeTests, return(), Input(), static(), WorkflowNodeInput(), Execute_AppliesTagReplacements() (+6 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, WorkflowOrchestratorTests, ProduceImage_IsTrue_WhenWorkflowHasAiImageNode(), ProduceImage_Set_ThrowsNotSupported(), Properties_AreConfigured(), return(), static(), OrchestrateAsync_ReturnsPostMap_OnSuccess() (+6 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_ReturnsEmptyArray(), XPoster.Tests.Services (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProvider(), LocalOverrideTimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, BuildCreds(), SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), BuildSender(), InSender_ImplementsISender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), Constructor_WithNullLogger_ThrowsArgumentNullException(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, TryGet_ReturnsFalseAndNullModelName_WhenNotSupported(), Constructor_NullDictionary_Throws(), Supports_ReturnsTrueForRegisteredModelClass(), GetRequired_Throws_WhenNotSupported(), Supports_ReturnsFalseForMissingModelClass(), Empty_SupportsNoModelClass() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, Execute_Throws_WhenValidProviderNotRegistered(), AiImageNodeTests, Execute_ReturnsFailure_WhenRequired_AndImageMissing(), Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing(), Execute_ReturnsMediaAttachment_OnSuccess(), Execute_ReturnsNullOutput_OnSoftFailure(), return() (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceModelId_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests, Validate_MissingApiKey_Fails() (+5 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.15
Nodes (13): XApiClientTests.cs, CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload(), CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails(), CreateTweetAsync_WhenBodyCarriesErrorsArray_ThrowsXApiException(), CreateTweetAsync_WithText_ReturnsTweetId(), foreach(), UploadMediaAsync_LargeImage_SplitsIntoMultipleSegments(), XPoster.Tests.SenderPlugins (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsPropertyIsNull(), ConfigurationTagReplacementProviderTests, GetReplacements_Should_ReturnEmptyDictionary_When_ReplacementsIsEmpty(), Constructor_Should_Throw_When_OptionsIsNull(), foreach(), GetReplacements_Should_PreserveAllEntries_When_MultipleReplacementsConfigured() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, MessageMaxLength_Returns2800(), InSender(), InSenderTests(), Constructor_InitializesCorrectly(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenBlobDeleteFails_LogsError(), RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenNoPendingContainers_DoesNothing() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_RequestUsesImageQuantityFromRequest(), MakeRequest(), GenerateImageAsync_Returns429_LogsWarning(), MakeHandlerMock(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, var(), AzureFoundryService(), GenerateImageAsync(), if(), GetChatCompletionsEndpoint(), catch() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, UploadMediaAsync(), InitializeMediaAsync(), ArgumentException(), CreateTweetAsync(), HasErrorPayload(), BuildSignedRequest(), for() (+4 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_Should_ReturnNoOrchestrator_WhenWorkflowDefinitionMissing(), Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(), XPoster.Tests.Orchestrators, Resolve_Should_ReturnWorkflowOrchestrator_WhenWorkflowDefinitionIsRegistered(), typeof(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, if(), foreach(), ConfigurationStepOptionsResolverTests, BuildConfig(), Resolve_BindsImageProperties_WhenPresent(), Resolve_BindsMaxOutputLength_WhenPresent() (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, XPoster.Tests.Extensions, AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly(), AddXPosterAiProviders_RegistersFalAi_AsImageOnly(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, if(), ComputeSignature(), ComputeSignatureBaseString(), foreach(), GetBaseUri(), BuildAuthorizationHeader() (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, Constructor_Should_PreserveHour_ForBoundaryValues(), XPoster.Tests.Models, Constructor_Should_SetAllFields(), Constructor_Should_PreserveOrderOfSenderPlatforms(), typeof(), OrchestratorContextKey_Should_BeSet_WhenProvided() (+3 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), XPoster.Tests.SenderPlugins, new(), Platform_ReturnsInstagram(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), BuildCreds() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.35
Nodes (11): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, PercentEncode_InputValue_ReturnsExpectedEncoding(), XOAuth1SignerTests, XPoster.Tests.SenderPlugins, ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString(), BuildCredentials(), ComputeSignature_PhotoExample_ReturnsExpectedBase64() (+3 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenLinkedInReturns200_ReturnsTrue(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), ValidPost() (+3 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, OrchestrateAsync_ReturnsEmptyList(), NoOrchestratorTests, Name_IsNoOrchestrator(), Build(), SendIt_Set_ThrowsNotImplementedException(), SupportedPlatforms_IsEmpty() (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WithValidOptions_ReturnsSuccess(), ValidOptions(), XPoster.Tests.Models, Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WhenEndpointIsEmpty_ReturnsFailed(), PerplexityOptionsValidatorTests (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithEmptyImageArray_ReturnsFalse(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), IgSenderSendAsyncTests, BuildSender(), IgSender(), SendAsync_WithNoImage_ReturnsFalse() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, XPoster.Services, MetaPublishingService(), GetApiVersion(), HttpRequestException(), if(), GetContainerStatusAsync() (+2 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_Rethrow_When_Factory_Throws(), XFunctionTests() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildFactory(), BuildCreds(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), FbSenderSendAsyncTests, SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, FbSender(), XPoster.SenderPlugins, if(), HandleResponseAsync(), PublishPhotoAsync(), SendAsync() (+2 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), FbSenderImageFlowTests, BuildCreds(), BuildFactory(), InvalidImageBytes(), HttpRequestException(), XPoster.Tests.SenderPlugins (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), PendingContainer(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), CreateTimerInfo() (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedTests, RSSFeed_RecordEquality_SameValues_AreEqual(), XPoster.Tests.Models, RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, if(), AiModelCatalog(), GetRequired(), InvalidOperationException(), Supports(), TryGet() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoService(), GetCryptoValue_ReturnsParsedValue_WhenNumericString(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), MakeService(), XPoster.Tests.Services (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, BuildSender(), XSenderResilienceTests, SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), SendAsync_WhenTextTweetReturns402_ReturnsFalseAndLogsError() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.22
Nodes (9): InSender.cs, XPoster.SenderPlugins, ResolveAuthorUrn(), using(), SendAsync(), catch(), Exception(), generatePayLoad() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, HttpResponseMessage(), XPoster.Tests.SenderPlugins, SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), XPoster.Tests.Orchestrators, PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, HttpClientExtensionsTests, foreach(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_CanCreateAllExpectedNamedClients() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, Input(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), Execute_UsesDefaultSymbol_WhenNotProvided(), Execute_ReturnsZero_WhenCryptoServiceReturnsZero(), AcquireCryptoValueNodeTests(), XPoster.Tests.Workflows.Nodes (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, BuildDelayedHandler(), HttpResponseMessage(), XPoster.Tests.Integration, BuildSequenceHandler(), params(), BuildProviderWithHandler() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), catch(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), for(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, XPoster.Workflows.Engine, while(), if(), ExecuteAsync(), WorkflowExecutionEngine(), WorkflowExecutionResult() (+1 more)

### Community 80 - "Entity (Community 80)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionDiffersFromEnumName(), GetLabel_DescriptionMatchesEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts

### Community 79 - "Entity (Community 79)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, HasData(), SetData(), XPoster.Workflows.Models, if(), KeyNotFoundException(), WorkflowContext

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, new(), Execute_OmitsDelta_WhenActualValueZeroOrMissing(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), CreateNode(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), XPoster.Tests.Workflows.Nodes, WorkflowNodeInput()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, CreateFactory(), SetupMocksForOrchestratorFactory(), OrchestratorFactoryTests(), WorkflowProfile(), new(), CreateFactoryWithProfiles(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty(), Post_EmptyContent_IsAllowed(), PostTests, XPoster.Tests.Models

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobUploadResult(), BlobStorageService(), DeleteAsync(), UploadAsync(), XPoster.Services, if()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, AIResponse, Choice, OpenAIImageResponse, XPoster.Models, ImageData, Message

### Community 83 - "Entity (Community 83)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, Execute_ReturnsFailure_WhenNoUrlsProvided(), FetchRssNodeTests, return(), foreach(), Execute_ReturnsFailure_WhenNoContentRetrieved(), static(), XPoster.Tests.Workflows.Nodes

### Community 89 - "Entity (Community 89)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, catch(), if(), GetImageGenerationEndpoint(), GenerateImageAsync(), FalAiImageService(), XPoster.Services

### Community 86 - "Entity (Community 86)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, CaptureLoggerProvider(), CaptureLogger(), CreateLogger(), Dispose(), IsEnabled()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, static(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Execute_Throws_WhenProviderNameIsUnknown(), Execute_ReturnsFailure_WhenProviderReturnsEmpty(), AiTextNodeTests, return()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, XPoster.Tests.Models, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), DeepSeekOptionsValidatorTests, ValidOptions()

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, XPoster.Workflows.Nodes, WorkflowNodeResult(), if(), ExecuteAsync(), foreach(), FetchRssNode()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, foreach(), ExecuteAsync(), FanOutSendNode(), XPoster.Workflows.Nodes, if(), WorkflowNodeResult()

### Community 73 - "Entity (Community 73)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ExtractFalAiBytesAsync(), XPoster.Services, ExtractOpenAiBytes(), LogAndReturnEmpty(), ParseImageResponseAsync(), ExtractAzureFoundryBytesAsync(), BuildChatPayload()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, InSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), TestOrchestrator(), BaseOrchestratorTests(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, catch(), SendAsync(), XPoster.SenderPlugins, XSender(), if()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, XPoster.Services, if(), foreach(), TagReplacementService(), Apply()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, XPoster.Workflows.Nodes, WorkflowNodeResult(), if(), ExecuteAsync(), AiImageNode()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, AiTextNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes, if(), ExecuteAsync()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, XPoster.SenderPlugins, if(), IgSender(), SendAsync(), catch()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, GenerateTextAsync(), var(), catch(), while(), XPoster.Services, GenerateImageAsync()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XSenderSendAsyncTests(), SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 102 - "Entity (Community 102)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), IContainerStateStore, XPoster.Contracts, SaveAsync(), UpdateStatusAsync()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), HttpResponseMessage()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, Validate(), XPoster.Credentials, if(), InvalidOperationException(), CredentialsStartupValidator(), catch()

### Community 90 - "Entity (Community 90)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, NoOrchestrator(), Resolve(), WorkflowOrchestrator(), XPoster.Orchestrators, ResolveSenders(), catch()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), if(), Run(), XPoster, XFunction()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, UpdateStatusAsync(), SaveAsync(), InMemoryContainerStateStore, GetPendingAsync(), XPoster.Services

### Community 91 - "Entity (Community 91)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, XPoster.Tests.Helpers, var(), StubHttpMessageHandler(), if(), CapturedRequest(), BuildSequenceHandler()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), AzureFoundryOptionsValidatorTests, Validate_MissingRequiredProperties_Fails()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, InvalidOperationException(), if(), foreach(), AddWorkflows(), XPoster.Workflows.Configuration

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, XPoster.Contracts, DeleteAsync(), IBlobStorageService, UploadAsync()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, if(), Validate(), XPoster.Credentials, FacebookCredentialsValidator

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, StringContent()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 109 - "Entity (Community 109)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, XPoster.Tests.Providers

### Community 110 - "Entity (Community 110)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, SendAsync(), XPoster.SenderPlugins, DryRunSender(), if()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), XPoster.Tests.Services, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, if(), ExecuteAsync(), BuildPowerLawPostNode(), XPoster.Workflows.Nodes

### Community 129 - "Entity (Community 129)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, for(), Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptionsTests, AzureFoundryOptions_Defaults_AreCorrect(), AzureFoundryOptions_DoesNotExpose_ApiVersionProperty()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), var(), Execute_Throws_WhenProviderNameIsUnknown(), Execute_PassesStepOptionsToImagePromptRequest(), Execute_ReturnsNullOutput_OnEmptyArray()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, nameof(), if(), Validate(), XPoster.Models

### Community 114 - "Entity (Community 114)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_PassesStepOptionsToPromptRequest(), Execute_ReturnsGeneratedText(), Input(), var(), Execute_Throws_WhenValidProviderNotRegistered()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, ThrowIfNotSuccess(), SignRequest(), FinalizeMediaAsync(), if(), AppendMediaSegmentsAsync()

### Community 124 - "Entity (Community 124)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, SetData(), HasData(), IWorkflowContext, XPoster.Workflows.Models

### Community 122 - "Entity (Community 122)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, AcquireCryptoValueNode(), ExecuteAsync(), WorkflowNodeResult(), XPoster.Workflows.Nodes

### Community 123 - "Entity (Community 123)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, if(), nameof(), Validate(), XPoster.Models

### Community 125 - "Entity (Community 125)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, IgSender_ImplementsISender(), IgSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSenderTests(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptionsTests, XPoster.Tests.Models, DeepSeekOptions_DoesNotExpose_ApiVersionProperty()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, HasCycle(), foreach(), if(), XPoster.Workflows.Engine

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, if(), Uri(), BlobServiceClient(), DefaultAzureCredential()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, XPoster.Models, Validate(), nameof(), if()

### Community 135 - "Entity (Community 135)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, var(), MakeNoOpClient(), MakeDownloadClient(), JsonResponse(), HttpClient()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.33
Nodes (6): XApiException.cs, XApiException(), foreach(), catch(), BuildMessage(), XPoster.SenderPlugins

### Community 107 - "Entity (Community 107)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, IMetaPublishingService, GetContainerStatusAsync(), XPoster.Contracts, PublishContainerAsync()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, InstagramCredentialsValidator, if(), XPoster.Credentials, Validate()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, if(), BuildPowerLawPostNodeTests(), Execute_DateBeforeGenesis_ReturnsFailure(), Execute_UsesSymbol_ForPostTag(), Input()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, WorkflowNodeInput(), var(), Execute_ConcatenatesMultipleFeeds(), Input(), Execute_CallsFeedServiceForMultipleUrls()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, IsJsonLike(), catch(), GetProvider(), return(), XPoster.Workflows.Utilities

### Community 112 - "Entity (Community 112)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, if(), nameof(), OrchestratorFactory(), ResolveWorkflowOrchestrator(), CreateEmptyNoOrchestrator()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), ISlotProfileProvider, XPoster.Contracts

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, XPoster.Workflows.Engine, IWorkflowEngine, ExecuteAsync()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, Resolve(), XPoster.Contracts, IOrchestratorFactory

### Community 153 - "Entity (Community 153)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, HttpResponseMessage(), BuildApiClient(), if(), OkJson()

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, SendAsync(), XPoster.Contracts

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, if(), ValidateConnectivity(), XPoster.Models

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, GetCurrentTime(), LocalOverrideTimeProvider()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, IWorkflowNode, XPoster.Workflows.Abstractions, ExecuteAsync()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, XPoster.Workflows.Services, Resolve(), ConfigurationStepOptionsResolver()

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, ImagePromptRequest, XPoster.Models, PromptRequest

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), CreateValidPng(), XPoster.Tests.Helpers

### Community 145 - "Entity (Community 145)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, XPoster.Providers, TimeProvider, GetCurrentTime()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, XPoster.Orchestrators, WorkflowOrchestrator(), if()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, XPoster.Workflows.Configuration, WorkflowDefinition(), ToDefinition()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, SendAsync(), params(), BuildFactory(), _responder()

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, XPoster.Workflows.Services, Resolve(), IStepOptionsResolver

### Community 143 - "Entity (Community 143)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 141 - "Entity (Community 141)"
Cohesion: 0.40
Nodes (5): FeedService.cs, GetFeedsAsync(), Exception(), XPoster.Services, catch()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests

### Community 168 - "Entity (Community 168)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, GenerateTextAsync(), if(), XPoster.Services, var()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 162 - "Entity (Community 162)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, XPoster.Credentials, if(), Validate()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), XPoster.Contracts, ITagReplacementService

### Community 161 - "Entity (Community 161)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, GetCurrentTime(), XPoster.Contracts, ITimeProvider

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, GenerateImageAsync(), XPoster.Contracts

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, ITagReplacementProvider, GetReplacements()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, GenerateTextAsync(), XPoster.Contracts

### Community 138 - "Entity (Community 138)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), MaskUrlTelemetryProcessor(), Process()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, var(), XPoster.Services, if(), GenerateTextAsync()

### Community 165 - "Entity (Community 165)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, XPoster.Contracts, Validate()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, GetCryptoValue(), XPoster.Contracts, ICryptoService

### Community 163 - "Entity (Community 163)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, IFeedService, XPoster.Contracts, GetFeedsAsync()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, XPoster.Contracts, IAiProviderOptions, IAiProviderSection

### Community 136 - "Entity (Community 136)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, OpenAiService(), if(), GetImageGenerationEndpoint(), GetChatCompletionsEndpoint()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 181 - "Entity (Community 181)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, var(), WorkflowExecutionResult(), new()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, GetLabel(), XPoster.Contracts

### Community 188 - "Entity (Community 188)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpClients()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, var(), if(), SetupSender()

### Community 185 - "Entity (Community 185)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), DeepSeekService(), GetChatCompletionsEndpoint()

### Community 182 - "Entity (Community 182)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, catch(), if(), return()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), catch(), XPoster.Services

### Community 184 - "Entity (Community 184)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), PerplexityService(), while()

### Community 173 - "Entity (Community 173)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, XPoster.Extensions, AddAiProviderOptions()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, GetProfiles(), XPoster.Providers, ConfigurationSlotProfileProvider()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), StringContent(), for()

### Community 180 - "Entity (Community 180)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, XPoster.Extensions, AddXPosterAiProviders()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 176 - "Entity (Community 176)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), var(), StubNode()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, XPoster.Workflows.Engine, WorkflowNodeDefinition()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, BaseOrchestrator(), PostAsync(), XPoster.Orchestrators

### Community 175 - "Entity (Community 175)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, XPoster.Credentials, AddCredentials()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, XPoster.Workflows.Models, MediaAttachment()

### Community 205 - "Entity (Community 205)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, XPoster.Models, RSSFeed

### Community 197 - "Entity (Community 197)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, WorkflowNodeResult(), XPoster.Workflows.Abstractions

### Community 198 - "Entity (Community 198)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, XPoster.SenderPlugins, DryRunMaxLengthSender()

### Community 204 - "Entity (Community 204)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 200 - "Entity (Community 200)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 199 - "Entity (Community 199)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 201 - "Entity (Community 201)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, XPoster.Workflows.Engine, WorkflowExecutionResult()

### Community 202 - "Entity (Community 202)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 203 - "Entity (Community 203)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 190 - "Entity (Community 190)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), foreach(), resolve()

### Community 196 - "Entity (Community 196)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), XPoster.Models, foreach()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, DryRunShortLengthSender(), XPoster.SenderPlugins

### Community 192 - "Entity (Community 192)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, ExecuteAsync(), new(), Node()

### Community 193 - "Entity (Community 193)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, XPoster.Workflows.Abstractions, ITerminalNode

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, WorkflowNodeInput(), XPoster.Workflows.Abstractions

### Community 220 - "Entity (Community 220)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, XPoster.Workflows.Models, WorkflowContextKeys.cs

### Community 233 - "Entity (Community 233)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 232 - "Entity (Community 232)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, if(), foreach()

### Community 234 - "Entity (Community 234)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, AiModelClass.cs, XPoster.Contracts

### Community 229 - "Entity (Community 229)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 230 - "Entity (Community 230)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 231 - "Entity (Community 231)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, InvalidOperationException(), if()

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, PromptStepOptions.cs, PromptStepOptions.cs

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): MediaType.cs, MediaType.cs, XPoster.Workflows.Models

### Community 223 - "Entity (Community 223)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 228 - "Entity (Community 228)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 226 - "Entity (Community 226)"
Cohesion: 1.00
Nodes (3): SlotScheduleOptions.cs, SlotScheduleOptions.cs, XPoster.Models

### Community 219 - "Entity (Community 219)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, nameof(), if()

### Community 206 - "Entity (Community 206)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 218 - "Entity (Community 218)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 207 - "Entity (Community 207)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, BlobStorageOptions.cs, XPoster.Models

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 209 - "Entity (Community 209)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 211 - "Entity (Community 211)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 210 - "Entity (Community 210)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 208 - "Entity (Community 208)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 215 - "Entity (Community 215)"
Cohesion: 1.00
Nodes (3): XPoster.Contracts, ContainerStatus.cs, ContainerStatus.cs

### Community 216 - "Entity (Community 216)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 212 - "Entity (Community 212)"
Cohesion: 0.67
Nodes (3): FeedService.cs, if(), FeedService()

### Community 214 - "Entity (Community 214)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 213 - "Entity (Community 213)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 236 - "Entity (Community 236)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

### Community 235 - "Entity (Community 235)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

