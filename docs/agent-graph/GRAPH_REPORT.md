# Graph Report - XPoster  (2026-09-16)

## Summary
- 2037 nodes · 3459 edges · 249 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Contracts` - 2 edges
2. `XPoster.Extensions` - 2 edges
3. `XPoster.Contracts` - 2 edges
4. `XPoster.Contracts` - 2 edges
5. `ITextToImageProvider` - 2 edges
6. `ITimeProvider` - 2 edges
7. `ITagReplacementProvider` - 2 edges
8. `XPoster.Models` - 2 edges
9. `XPoster.Tests.Providers` - 2 edges
10. `XPoster.Tests.Providers` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_FalAi_EmptyImagesArray_ReturnsEmptyArray(), ParseImageResponseAsync_FalAi_DownloadFails_ReturnsEmptyArray(), ParseImageResponseAsync_FalAi_ValidUrl_ReturnsDownloadedBytes(), ParseImageResponseAsync_FalAi_MissingUrlProperty_ReturnsEmptyArray(), AiServiceHelperTests, AzureFoundryUrlJson() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.09
Nodes (43): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_WhenFallbackUrlIsFromDifferentOrigin_LogsWarning(), GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyByteArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyByteArray(), GenerateImageAsync_WhenInputTextIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionOnPost_ReturnsEmptyByteArray(), GenerateTextAsync_RequestBodyContainsModelFromOptions() (+35 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenDataArrayIsEmpty_ReturnsEmptyArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyArray(), GenerateImageAsync_WhenB64JsonIsNull_ReturnsEmptyArray(), GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_LogsError(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, static(), XPoster.Tests.Services, Parse_AzureFoundry_MissingDataProperty_ReturnsEmpty(), new(), Parse_AzureFoundry_MissingBothB64AndUrl_ReturnsEmpty(), Parse_AzureFoundry_ValidB64_ReturnsBytes(), Parse_FalAi_DownloadThrows_LogsError() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WhenProbeKeyPresent_ReturnsTrue(), SendAsync_WhenProbeKeyMissing_ReturnsFalse(), SendAsync_WhenProbeKeyPresent_LogsPostContent(), MaxSender_ImplementsISender(), MaxSender_MessageMaxLength_IsIntMaxValue(), MaxSender_Platform_IsDryRunMaxLength() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AzureFoundryOptionsExtensionsTests, AddPerplexityOptions_RegistersValidator(), AddOpenAiOptions_RegistersValidator(), AddPerplexityOptions_BindsOptionsFromCorrectSection(), SectionName_IsAzureFoundry(), PerplexityOptionsExtensionsTests (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GenerateTextAsync_WhenMaxOutputLengthIsNull_CallsApiOnce(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenFirstResponseStillTooLong_RetriesAndReturnsSecondResponse(), GenerateTextAsync_WhenInputTextLabelIsNull_FallsBackToDefaultLabel(), BuildService(), BuildImagePromptRequest() (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, FbSender_ImplementsISender(), Constructor_WithNullFactory_ThrowsArgumentNullException(), FbSender(), Constructor_WithNullLogger_ThrowsArgumentNullException(), Constructor_WithNullBlobStorage_ThrowsArgumentNullException(), BuildFactory() (+18 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, ImagePromptDerivationRequest(), GenerateTextAsync_WhenResponseFitsWithinMaxOutputLength_ReturnsSingleCallResult(), HttpResponseMessage(), GenerateTextAsync_WhenUsedForImagePromptDerivation_ReturnsPrompt(), GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsBadGateway_ReturnsEmptyString() (+17 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetProvider_UsesProvidedDefault_WhenMissing(), NodeParameterExtractorTests, XPoster.Tests.Workflows.Utilities, GetParameter_MalformedJsonArrayString_FallsBackToString(), GetParameter_JsonElement_ToString(), GetParameter_JsonObjectString_ToDictionary() (+17 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, XSenderTests, SendAsync_WithImage_WhenUploadFails_ReturnsFalseAndLogsError(), XSender(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, MessageMaxLength_Returns250() (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, WorkflowExecutionEngineTests, _onExecute(), static(), return(), Cyclic(), Execute_Cycle_ReturnsFailure_WithDescriptiveError(), Diamond() (+13 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.11
Nodes (19): HttpResponseBodyLoggingHandlerTests.cs, FixedResponseHandler(), BuildClient(), BinaryResponseHandler(), LogWasCalled(), HttpClient(), HttpResponseBodyLoggingHandlerTests, if() (+11 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, BuildSender(), CreateMalformedPngBytes(), IgSender(), IgSenderImageFlowTests, NormalizeImage_WithValidPng_ReturnsJpegBytes(), NormalizeImage_WithValidJpeg_ReturnsSameBytes() (+10 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, FeedServiceTests, BuildRssXml(), FakeHttpMessageHandler(), BuildService(), FeedService(), BuildFactory() (+10 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, HasData_ReturnsFalse_WhenKeyMissing(), ConcurrentSetData_DoesNotThrow(), catch(), ConcurrentReadWrite_DoesNotThrow(), GetData_ThrowsOnMissingKey(), GetData_ThrowsOnTypeMismatch() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, GetRole(), return(), XPoster.Tests.Services, BuildRequest(), BuildChatPayload_SubstitutesCustomLabelInUserMessage(), BuildChatPayload_WhenInputTextLabelIsNull_FallsBackToTextPlaceholder() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, PerplexityOptions_ModelCatalog_ExposesTextOnly(), XPoster.Tests.Models, ModelCatalog_EmptyModelName_NotExposedAsSupported(), FalAiOptions_ImplementsIAiProviderOptions(), FalAiOptions_NumInferenceSteps_RemainsOnConcreteClass(), FalAiOptions_ModelCatalog_ExposesImageOnly() (+10 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequestTests, PromptRequest_RequiredProperties_AreSetCorrectly(), PromptRequest_ValueEquality_SameValues_AreEqual(), PromptRequest_Temperature_AcceptsZeroAndOne(), PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), PromptRequest_OptionalProperties_DefaultToNull() (+9 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, XPoster.Tests.Workflows.Configuration, AddWorkflows_Registers_KeyedNodes(), AddWorkflows_Registers_StepOptionsResolver(), AddWorkflows_WithMultipleTerminalNodes_ThrowsInvalidOperationException(), AddWorkflows_Registers_WorkflowDefinitions_AsKeyedSingletons(), AddWorkflows_Registers_WorkflowEngine() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, GetContainerStatusAsync_WhenStatusInNestedField_ReturnsCode(), GetContainerStatusAsync_WhenCancelled_ThrowsTaskCanceledException(), GetContainerStatusAsync_WhenNotFound_ThrowsHttpRequestException(), GetContainerStatusAsync_WhenOk_ReturnsStatusCode(), GetContainerStatusAsync_WhenResponseBodyIsEmpty_ThrowsJsonException(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException() (+9 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, GetProfiles_Should_SkipSlot_WithNoWorkflowKey(), GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes(), XPoster.Tests.Providers, new(), GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain(), GetProfiles_Should_MapEachSlotToWorkflowOrchestrator() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, XPoster.Tests.Services, UpdateStatusAsync_WhenEntryDoesNotExist_AddsNonPendingEntryWithEmptyBlobName(), UpdateStatusAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException(), UpdateStatusAsync_WithNullCreationId_ThrowsArgumentNullException(), UpdateStatusAsync_WhenEntryExists_UpdatesStatusAndRemovesItFromPending(), UpdateStatusAsync_CanMoveEntryBackToPending() (+8 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, WorkflowDefinition(), ValidateStructural_ValidLinearDag_ReturnsNull(), ValidateTerminalNodeContract_TerminalDoesNotImplementContract_ReturnsError(), ValidateTerminalNodeContract_TerminalImplementsContract_ReturnsNull(), ValidateTerminalNodeContract_UnresolvableTerminalType_ReturnsNull(), Cyclic(), ValidateStructural_MultipleTerminalNodes_ReturnsError() (+8 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.24
Nodes (16): HttpResponseBodySanitizerTests.cs, HttpResponseBodySanitizerTests.cs, SanitizeUrl_MasksAccessTokenQuery(), SanitizeUrl_NoQuery_ReturnsAsIs(), XPoster.Tests.Extensions, Sanitize_MasksBearerTokenInHeader(), HttpResponseBodySanitizerTests, Sanitize_LeavesCleanTextUnchanged() (+8 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, XPoster.Tests.SenderPlugins, PostWithImage(), BuildSender(), IgSenderResilienceTests, IgSender(), new() (+7 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, UploadAsync_SasUriExpiry_IsApproximately30Minutes(), DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), DeleteAsync_WithNullBlobName_ThrowsArgumentException(), DeleteAsync_WithEmptyBlobName_ThrowsArgumentException(), DeleteAsync_WhenBlobExists_DeletesSuccessfully(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName() (+7 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenDataIsNull_DoesThrow(), MaskUrlTelemetryProcessorTests, Initialize_WhenTelemetryIsNotDependency_DoesNothing() (+7 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, AddAiProviderOptions_RegistersAllFiveOptionTypes(), AddAiProviderOptions_BindsDeepSeekOptions_FromCorrectSection(), AddAiProviderOptions_DoesNotDuplicateValidatorRegistrations_WhenCalledOnce(), AddAiProviderOptions_BindsFalAiOptions_FromCorrectSection(), AddAiProviderOptions_BindsOpenAiOptions_FromCorrectSection(), AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection() (+7 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, WorkflowNodeInput(), FanOutSendNodeTests, Execute_TwoSenders_ResummarisesForSmallSenderAndKeepsVariantForWideSender(), return(), static(), Input(), Execute_TwoSenders_DistinctPlatforms_ReSummarisationRunsPerSender() (+6 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, XPoster.Tests.Orchestrators, WorkflowOrchestratorTests, ProduceImage_IsTrue_WhenWorkflowHasAiImageNode(), static(), return(), Properties_AreConfigured(), ProduceImage_Set_ThrowsNotSupported() (+6 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Message_CanBeCreated_WithContent(), Choice_CanBeCreated_WithMessage(), ImageData_CanBeCreated_WithUrl(), AIResponse_CanBeCreated_WithChoices(), RSSFeed_CanBeCreated_WithAllProperties(), OpenAIImageResponse_CanBeCreated_WithData() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, HandleFinishedAsync(), foreach(), catch(), if(), Run(), ProcessContainerAsync() (+6 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.29
Nodes (13): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, BuildPhotoParameters(), XOAuth1SignerTests, ComputeSignature_PhotoExample_ReturnsExpectedBase64(), PercentEncode_InputValue_ReturnsExpectedEncoding(), ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString(), ExtractHeaderValue() (+5 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, Constructor_AlwaysEmitsDevOverrideWarning(), GetCurrentTime_WhenForceHourIsValid_ReturnsUtcKind(), GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), GetCurrentTime_WhenForceHourIsValid_ReturnsForcedHour(), GetCurrentTime_WhenForceHourIsOutOfRange_WrapsViaDateTimeOverflow() (+5 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, Execute_ReturnsNullOutput_OnSoftFailure(), Execute_ReturnsMediaAttachment_OnSuccess(), Execute_ReturnsFailure_WhenRequired_AndImageMissing(), AiImageNodeTests, XPoster.Tests.Workflows.Nodes, Execute_Throws_WhenValidProviderNotRegistered(), WorkflowNodeInput() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): XApiClientTests.cs, UploadMediaAsync_WhenInitRejected_ThrowsXApiException(), XPoster.Tests.SenderPlugins, XApiClientTests, CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails(), UploadMediaAsync_LargeImage_SplitsIntoMultipleSegments(), CreateTweetAsync_WhenBodyCarriesErrorsArray_ThrowsXApiException(), CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), ValidOptions(), Validate_WhitespaceModelId_Fails(), XPoster.Tests.Models, Validate_WhitespaceApiKey_Fails(), Validate_ImageModelNameWithAllowedSpecialChars_Succeeds() (+5 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_TextOnly_WhenPostCreationFails_ReturnsFalse(), BuildSender(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), BuildCreds(), Constructor_WithNullLogger_ThrowsArgumentNullException(), InSender_ImplementsISender(), SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn() (+5 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), FalImageJson(), BuildService(), FalAiImageServiceTests, GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), GenerateImageAsync_ValidResponse_ReturnsImageBytes() (+5 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, TryGet_ReturnsFalseAndNullModelName_WhenNotSupported(), TryGet_ReturnsTrueAndPopulatesModelName_WhenSupported(), XPoster.Tests.Models, GetRequired_Throws_WhenNotSupported(), AiModelCatalogTests, Empty_SupportsNoModelClass() (+5 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnReadOnlyDictionary(), XPoster.Tests.Providers, GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), ConfigurationTagReplacementProvider(), foreach(), Constructor_Should_Throw_When_OptionsIsNull() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_ForMissingContextKey_ReturnsNoOrchestrator(), foreach(), NoOrchestrator_SupportedPlatforms_IsEmpty(), XPoster.Tests.Orchestrators, Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(), typeof(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour() (+4 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_Returns429_LogsWarning(), GenerateImageAsync_RequestUsesImageQuantityFromRequest(), GenerateImageAsync_MalformedJson_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri(), FalAiImageService(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, Resolve_BindsImageProperties_WhenPresent(), Resolve_Throws_WhenStepMissing(), Resolve_Throws_OnNullOrWhitespaceStepId(), Resolve_ReturnsStepOptions_WhenSectionExists(), XPoster.Tests.Workflows.Services, Resolve_BindsMaxOutputLength_WhenPresent() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, InitializeMediaAsync(), ArgumentException(), for(), HasErrorPayload(), CreateTweetAsync(), catch(), BuildSignedRequest() (+4 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsInProgress_SkipsContainer(), CreateSut(), RunAsync_WhenNoPendingContainers_DoesNothing(), RunAsync_WhenMultiplePendingContainers_ProcessesAll() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), Platform_ReturnsLinkedIn(), SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_ValidPost_TriesLinkedInAndReturnsFalse(), SendAsync_TextOnly_WithOrgId_UsesOrganizationUrn(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse() (+4 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AiProviderServiceCollectionExtensionsTests, AddXPosterAiProviders_RegistersFalAi_AsImageOnly() (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, OrchestratorContextKey_Should_BeSet_WhenProvided(), Constructor_Should_PreserveHour_ForBoundaryValues(), Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_SetAllFields(), OrchestratorContextKey_Should_BeNull_WhenNotProvided(), typeof() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, BuildAuthorizationHeader(), ComputeSignatureBaseString(), XPoster.SenderPlugins, GetBaseUri(), foreach(), PercentEncode() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, Constructor_WithNullLogger_ThrowsArgumentNullException(), MessageMaxLength_Returns2200(), new(), XPoster.Tests.SenderPlugins, Platform_ReturnsInstagram(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), BuildSender() (+3 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), BuildSender(), InSender(), InSenderResilienceTests, SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError() (+3 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), BuildSender(), SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), SendAsync_WithEmptyImageArray_ReturnsFalse(), IgSender() (+2 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, SendAsync(), PublishPhotoAsync(), if(), FbSender(), catch(), PublishTextOnlyAsync() (+2 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, XPoster.Tests, Run_Should_LogWarning_AndNotRethrow_When_CancelledGracefully(), Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_DoNothing_When_GeneratorIsDisabled() (+2 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), PerplexityOptionsValidatorTests, Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess() (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, BuildFactory(), SendAsync_WithCaptionLongerThanMax_StillPublishes_ReturnsTrue(), FbSenderSendAsyncTests, XPoster.Tests.SenderPlugins, SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue() (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, NoOrchestratorTests, Name_IsNoOrchestrator(), XPoster.Tests.Orchestrators, SendIt_IsAlwaysFalse(), SupportedPlatforms_IsEmpty(), OrchestrateAsync_ReturnsEmptyList() (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, HttpRequestException(), MetaPublishingService(), if(), PublishContainerAsync(), XPoster.Services, GetApiVersion() (+2 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, BuildSender(), XPoster.Tests.SenderPlugins, SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError(), XSenderResilienceTests, SendAsync_WhenTextTweetReturns402_ReturnsFalseAndLogsError() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.22
Nodes (9): InSender.cs, Exception(), using(), XPoster.SenderPlugins, generatePayLoad(), InvalidOperationException(), ResolveAuthorUrn(), SendAsync() (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, for(), catch(), Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_OnRetry_LogEntryIsEmitted(), XPoster.Tests.Integration, Polly_Facebook_RetriesOn429_AndEventuallySucceeds() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), HttpResponseMessage(), FbSenderResilienceTests (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, WorkflowExecutionEngine(), while(), if(), foreach(), ExecuteAsync(), WorkflowExecutionResult() (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), InvalidImageBytes(), FbSenderImageFlowTests, HttpRequestException(), BuildFactory(), BuildCreds() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, if(), Supports(), InvalidOperationException(), TryGet(), XPoster.Models, AiModelCatalog() (+1 more)

### Community 73 - "Entity (Community 73)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), CryptoService(), MakeService(), GetCryptoValue_ReturnsZero_WhenResponseIsNotNumeric(), XPoster.Tests.Services (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, foreach(), AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_RegistersIHttpClientFactory(), AddHttpClients_CanCreateAllExpectedNamedClients(), HttpClientExtensionsTests (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp(), RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenUpdateStatusThrows_PropagatesException(), RunAsync_WhenCancelled_StopsGracefully(), CreateTimerInfo(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), PendingContainer() (+1 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, Execute_ReturnsCryptoValue_WhenSymbolParameterProvided(), Execute_UsesDefaultSymbol_WhenNotProvided(), Input() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, XPoster.Tests.Models, RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeedTests, RSSFeed_RecordEquality_SameValues_AreEqual(), RSSFeed_CanCreateWithRequiredProperties(), RSSFeed_CanSetPublishDate() (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), XPoster.Tests.Orchestrators, PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_When_SendIt_IsFalse() (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, XPoster.Tests.Integration, params(), BuildSequenceHandler(), BuildDelayedHandler(), BuildProviderWithHandler(), var() (+1 more)

### Community 90 - "Entity (Community 90)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, Message, OpenAIImageResponse, XPoster.Models, ImageData, AIResponse, Choice

### Community 87 - "Entity (Community 87)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_DescriptionDiffersFromEnumName(), GetLabel_DescriptionMatchesEnumName(), GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), AiProviderExtensionsTests

### Community 85 - "Entity (Community 85)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_EmptyContent_IsAllowed(), PostTests, XPoster.Tests.Models, Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), Firm_IsNotNullOrEmpty()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ExtractAzureFoundryBytesAsync(), BuildChatPayload(), ParseImageResponseAsync(), LogAndReturnEmpty(), ExtractOpenAiBytes(), ExtractFalAiBytesAsync(), XPoster.Services

### Community 76 - "Entity (Community 76)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, foreach(), Execute_ReturnsFailure_WhenNoUrlsProvided(), FetchRssNodeTests, Execute_ReturnsFailure_WhenNoContentRetrieved(), static(), return(), XPoster.Tests.Workflows.Nodes

### Community 75 - "Entity (Community 75)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, CaptureLogger(), Dispose(), XPoster.Tests.Integration, CaptureLoggerProvider(), CreateLogger(), IsEnabled()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_MissingRequiredProperties_Fails(), Validate_ValidOptions_Succeeds(), ValidOptions(), DeepSeekOptionsValidatorTests, XPoster.Tests.Models

### Community 77 - "Entity (Community 77)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, TestOrchestrator(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse(), BaseOrchestratorTests(), PostAsync_DispatchesEachPostToAlignedSender()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, Execute_ReturnsFailure_WhenProviderReturnsEmpty(), WorkflowNodeInput(), static(), return(), Execute_Throws_WhenProviderNameIsUnknown(), XPoster.Tests.Workflows.Nodes, AiTextNodeTests

### Community 80 - "Entity (Community 80)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, XPoster.Workflows.Models, SetData(), HasData(), if(), KeyNotFoundException(), WorkflowContext

### Community 79 - "Entity (Community 79)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, CreateNode(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), new(), Execute_OmitsDelta_WhenActualValueZeroOrMissing()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobStorageService(), DeleteAsync(), UploadAsync(), BlobUploadResult(), if(), XPoster.Services

### Community 74 - "Entity (Community 74)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, XPoster.Services, FalAiImageService(), catch(), if(), GenerateImageAsync(), GetImageGenerationEndpoint()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse(), InSenderSendAsyncTests()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, foreach(), XPoster.Workflows.Nodes, FanOutSendNode(), WorkflowNodeResult(), ExecuteAsync(), if()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, SetupMocksForOrchestratorFactory(), OrchestratorFactoryTests(), new(), CreateFactoryWithProfiles(), CreateFactory(), WorkflowProfile(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, XPoster.Workflows.Nodes, ExecuteAsync(), WorkflowNodeResult(), FetchRssNode(), foreach(), if()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, if(), TagReplacementService(), XPoster.Services, foreach(), Apply()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, catch(), InvalidOperationException(), Validate(), XPoster.Credentials, CredentialsStartupValidator(), if()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.29
Nodes (7): AzureFoundryService.cs, while(), GetImageGenerationEndpoint(), GenerateTextAsync(), AzureFoundryService(), GenerateImageAsync(), XPoster.Services

### Community 99 - "Entity (Community 99)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLogger.cs, XPoster.Services, Log(), IsEnabledFor(), HttpResponseBodyLogger(), foreach(), while()

### Community 100 - "Entity (Community 100)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, XSender(), SendAsync(), if(), catch(), XPoster.SenderPlugins

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, Run(), catch(), if(), XPoster, XFunction()

### Community 96 - "Entity (Community 96)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, BuildSequenceHandler(), CapturedRequest(), StubHttpMessageHandler(), var(), XPoster.Tests.Helpers, if()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, XPoster.Orchestrators, WorkflowOrchestrator(), catch(), NoOrchestrator(), Resolve(), ResolveSenders()

### Community 94 - "Entity (Community 94)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), IContainerStateStore, XPoster.Contracts, UpdateStatusAsync(), SaveAsync()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, if(), foreach(), AddWorkflows(), InvalidOperationException(), XPoster.Workflows.Configuration

### Community 102 - "Entity (Community 102)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, GenerateTextAsync(), while(), XPoster.Services, var(), GenerateImageAsync(), catch()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XSenderSendAsyncTests()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.29
Nodes (7): HttpResponseBodyLoggingHandlerTests.cs, SendAsync(), SendAsync_NotEnabled_SuccessNotLogged(), SendAsync_OptOutHeader_LogsNothing(), static(), return(), var()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, AiTextNode(), WorkflowNodeResult(), if(), ExecuteAsync(), XPoster.Workflows.Nodes

### Community 109 - "Entity (Community 109)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, ValidOptions(), Validate_MissingRequiredProperties_Fails(), AzureFoundryOptionsValidatorTests

### Community 107 - "Entity (Community 107)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), if(), catch(), IgSender(), XPoster.SenderPlugins

### Community 106 - "Entity (Community 106)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), HttpResponseMessage(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), if(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, AiImageNode(), ExecuteAsync(), if(), XPoster.Workflows.Nodes, WorkflowNodeResult()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, XPoster.Services, InMemoryContainerStateStore, SaveAsync(), UpdateStatusAsync(), GetPendingAsync()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, XPoster.Credentials, FacebookCredentialsValidator, Validate(), if()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, XPoster.Models, nameof(), Validate(), if()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, HasCycle(), XPoster.Workflows.Engine, if(), foreach()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, OrchestratorFactory(), ResolveWorkflowOrchestrator(), nameof(), CreateEmptyNoOrchestrator(), if()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, Validate(), XPoster.Models, if(), nameof()

### Community 131 - "Entity (Community 131)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_Throws_WhenValidProviderNotRegistered(), var(), Input(), Execute_PassesStepOptionsToPromptRequest(), Execute_ReturnsGeneratedText()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, nameof(), Validate(), XPoster.Models, if()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), XPoster.Credentials, InstagramCredentialsValidator, if()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.33
Nodes (6): HttpResponseBodyLoggingHandler.cs, IsBinaryMediaType(), foreach(), HttpResponseBodyLoggingHandler(), XPoster.Services, SendAsync()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), XPoster.Tests.Services

### Community 124 - "Entity (Community 124)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullBlobStorageService_ThrowsArgumentNullException(), Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender_ImplementsISender(), IgSender(), IgSenderTests()

### Community 112 - "Entity (Community 112)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptionsTests, DeepSeekOptions_Defaults_AreCorrect(), DeepSeekOptions_DoesNotExpose_ApiVersionProperty(), XPoster.Tests.Models

### Community 110 - "Entity (Community 110)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, BlobServiceClient(), Uri(), if(), DefaultAzureCredential()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, WorkflowNodeResult(), XPoster.Workflows.Nodes, AcquireCryptoValueNode(), ExecuteAsync()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), XPoster.Tests.Integration, StringContent(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, XPoster.Workflows.Utilities, catch(), IsJsonLike(), return(), GetProvider()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), for(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 137 - "Entity (Community 137)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_ReturnsNullOutput_OnEmptyArray(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), Execute_Throws_WhenProviderNameIsUnknown(), var(), Execute_PassesStepOptionsToImagePromptRequest()

### Community 138 - "Entity (Community 138)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, XPoster.Contracts, DeleteAsync(), UploadAsync()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, Execute_ConcatenatesMultipleFeeds(), Execute_CallsFeedServiceForMultipleUrls(), Input(), WorkflowNodeInput(), var()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, XPoster.Workflows.Nodes, ExecuteAsync(), BuildPowerLawPostNode(), if()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), TimeProviderTests, XPoster.Tests.Providers, GetCurrentTime_ReturnsCurrentDateTime()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.33
Nodes (6): XApiException.cs, XApiException(), catch(), XPoster.SenderPlugins, foreach(), BuildMessage()

### Community 136 - "Entity (Community 136)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, XPoster.Workflows.Models, SetData(), HasData(), IWorkflowContext

### Community 135 - "Entity (Community 135)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, GetContainerStatusAsync(), PublishContainerAsync(), IMetaPublishingService

### Community 126 - "Entity (Community 126)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, MakeNoOpClient(), var(), HttpClient(), JsonResponse(), MakeDownloadClient()

### Community 127 - "Entity (Community 127)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, AzureFoundryOptions_Defaults_AreCorrect(), XPoster.Tests.Models, AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty()

### Community 115 - "Entity (Community 115)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Execute_DateBeforeGenesis_ReturnsFailure(), Execute_UsesSymbol_ForPostTag(), Input(), if(), BuildPowerLawPostNodeTests()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, XPoster.Models, nameof(), Validate(), if()

### Community 122 - "Entity (Community 122)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, ThrowIfNotSuccess(), SignRequest(), AppendMediaSegmentsAsync(), FinalizeMediaAsync(), if()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, XPoster.SenderPlugins, SendAsync(), if(), DryRunSender()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, XPoster.Contracts, GetReplacements(), ITagReplacementProvider

### Community 163 - "Entity (Community 163)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, if(), ValidateConnectivity(), XPoster.Models

### Community 164 - "Entity (Community 164)"
Cohesion: 0.40
Nodes (5): HttpClientExtensions.cs, XPoster.Extensions, AddResilientHttpClient(), AddHttpResponseBodyLogging(), AddHttpClients()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, XPoster.Contracts, GenerateImageAsync(), ITextToImageProvider

### Community 165 - "Entity (Community 165)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, ITimeProvider, GetCurrentTime()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, ExecuteAsync(), IWorkflowNode, XPoster.Workflows.Abstractions

### Community 179 - "Entity (Community 179)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, ExecuteAsync(), XPoster.Workflows.Engine, IWorkflowEngine

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, XPoster.Providers, GetCurrentTime()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, XPoster.Tests.Models, ValidOptions(), OpenAiOptionsValidatorTests

### Community 146 - "Entity (Community 146)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLoggingPipelineTests.cs, ResponseBodyLogging_429Sequence_LogsEachRetryAttemptAndFinalSuccess(), XPoster.Tests.Integration, return(), static()

### Community 144 - "Entity (Community 144)"
Cohesion: 0.40
Nodes (5): AzureFoundryService.cs, var(), if(), catch(), GetChatCompletionsEndpoint()

### Community 145 - "Entity (Community 145)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, BuildFactory(), params(), SendAsync(), _responder()

### Community 173 - "Entity (Community 173)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, ICredentialsStartupValidator, Validate(), XPoster.Contracts

### Community 168 - "Entity (Community 168)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetImageGenerationEndpoint(), if(), OpenAiService(), GetChatCompletionsEndpoint()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.40
Nodes (5): HttpResponseBodyLogger.cs, FormatResponseHeaders(), TruncateUtf8(), if(), SanitizeAndTruncate()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, XPoster.Tests.Helpers, CreateValidPng(), CreateValidJpeg()

### Community 171 - "Entity (Community 171)"
Cohesion: 0.40
Nodes (5): FeedService.cs, catch(), XPoster.Services, Exception(), GetFeedsAsync()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, XPoster.Workflows.Services, ConfigurationStepOptionsResolver(), Resolve()

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, ITextToTextProvider, GenerateTextAsync(), XPoster.Contracts

### Community 155 - "Entity (Community 155)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, if(), GenerateTextAsync(), var(), XPoster.Services

### Community 154 - "Entity (Community 154)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, OkJson(), BuildApiClient(), HttpResponseMessage(), if()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, XPoster.Providers, LocalOverrideTimeProvider(), GetCurrentTime()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor(), if(), Process()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, GetProfiles(), ISlotProfileProvider, XPoster.Contracts

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, PromptRequest, ImagePromptRequest, XPoster.Models

### Community 152 - "Entity (Community 152)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, Validate(), XPoster.Credentials, if()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, XPoster.Workflows.Configuration, ToDefinition(), WorkflowDefinition()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, Resolve(), IStepOptionsResolver, XPoster.Workflows.Services

### Community 162 - "Entity (Community 162)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, var(), XPoster.Services, if(), GenerateTextAsync()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, WorkflowOrchestrator(), if(), XPoster.Orchestrators

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderSection, XPoster.Contracts, IAiProviderOptions

### Community 142 - "Entity (Community 142)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), catch()

### Community 176 - "Entity (Community 176)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, IOrchestrator, XPoster.Contracts, PostAsync()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, SendAsync(), XPoster.Contracts, ISender

### Community 174 - "Entity (Community 174)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, XPoster.Contracts, ICryptoService, GetCryptoValue()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, XPoster.Contracts, GetFeedsAsync(), IFeedService

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), ITagReplacementService, XPoster.Contracts

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 183 - "Entity (Community 183)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 180 - "Entity (Community 180)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, Node(), new(), ExecuteAsync()

### Community 181 - "Entity (Community 181)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 182 - "Entity (Community 182)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Orchestrators, PostAsync(), BaseOrchestrator()

### Community 192 - "Entity (Community 192)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, MediaAttachment(), XPoster.Workflows.Models

### Community 200 - "Entity (Community 200)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, WorkflowNodeInput(), XPoster.Workflows.Abstractions

### Community 193 - "Entity (Community 193)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, ConfigurationSlotProfileProvider(), GetProfiles(), XPoster.Providers

### Community 199 - "Entity (Community 199)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, XPoster.Workflows.Abstractions, ITerminalNode

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, DryRunShortLengthSender(), XPoster.SenderPlugins

### Community 195 - "Entity (Community 195)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), StubNode(), var()

### Community 196 - "Entity (Community 196)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, GetChatCompletionsEndpoint(), while(), PerplexityService()

### Community 197 - "Entity (Community 197)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, catch(), GetCryptoValue(), XPoster.Services

### Community 198 - "Entity (Community 198)"
Cohesion: 0.50
Nodes (4): HttpResponseBodySanitizer.cs, foreach(), SanitizeUrl(), XPoster.Services

### Community 208 - "Entity (Community 208)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, PendingContainer(), XPoster.Models

### Community 209 - "Entity (Community 209)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, SetupSender(), if(), var()

### Community 215 - "Entity (Community 215)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, XPoster.Models, ScheduledOrchestrationProfile()

### Community 211 - "Entity (Community 211)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 210 - "Entity (Community 210)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, foreach(), resolve(), ValidateOptions()

### Community 212 - "Entity (Community 212)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, AddAiProviderOptions(), XPoster.Extensions

### Community 213 - "Entity (Community 213)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 214 - "Entity (Community 214)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, XPoster.Models, BlobUploadResult()

### Community 206 - "Entity (Community 206)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, DeepSeekService(), while(), GetChatCompletionsEndpoint()

### Community 207 - "Entity (Community 207)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, XPoster.Models, Post

### Community 205 - "Entity (Community 205)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, foreach(), Validate(), XPoster.Models

### Community 204 - "Entity (Community 204)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 201 - "Entity (Community 201)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, WorkflowNodeResult(), XPoster.Workflows.Abstractions

### Community 202 - "Entity (Community 202)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, DryRunMaxLengthSender(), XPoster.SenderPlugins

### Community 203 - "Entity (Community 203)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 191 - "Entity (Community 191)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 185 - "Entity (Community 185)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, Polly_LinkedIn_OnRetry_LogEntryIsEmitted(), StringContent(), catch()

### Community 187 - "Entity (Community 187)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, for(), StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest()

### Community 189 - "Entity (Community 189)"
Cohesion: 0.50
Nodes (4): HttpResponseBodyLoggingPipelineTests.cs, var(), ResponseBodyLogging_SuccessLogsBodyReadableByConsumer(), ResponseBodyLogging_402_LogsSanitizedBodyAtErrorWithHeaders()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, WorkflowExecutionResult(), new(), var()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, XPoster.Workflows.Engine, WorkflowNodeDefinition()

### Community 190 - "Entity (Community 190)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, XPoster.Workflows.Engine, WorkflowExecutionResult()

### Community 217 - "Entity (Community 217)"
Cohesion: 0.67
Nodes (3): HttpResponseBodySanitizer.cs, if(), Sanitize()

### Community 216 - "Entity (Community 216)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, if(), IsTransientHttpFailure()

### Community 232 - "Entity (Community 232)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, if(), nameof()

### Community 245 - "Entity (Community 245)"
Cohesion: 1.00
Nodes (3): LinkedInCredentials.cs, XPoster.Credentials, LinkedInCredentials.cs

### Community 244 - "Entity (Community 244)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, XPoster.Models, FalAiOptions.cs

### Community 246 - "Entity (Community 246)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, AzureFoundryOptions.cs, XPoster.Models

### Community 241 - "Entity (Community 241)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, if(), CryptoService()

### Community 242 - "Entity (Community 242)"
Cohesion: 1.00
Nodes (3): PerplexityOptions.cs, PerplexityOptions.cs, XPoster.Models

### Community 243 - "Entity (Community 243)"
Cohesion: 1.00
Nodes (3): XPoster.Models, OpenAiOptions.cs, OpenAiOptions.cs

### Community 233 - "Entity (Community 233)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, InvalidOperationException(), if()

### Community 234 - "Entity (Community 234)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 235 - "Entity (Community 235)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, AiModelClass.cs, XPoster.Contracts

### Community 236 - "Entity (Community 236)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 237 - "Entity (Community 237)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, PromptStepOptions.cs, XPoster.Workflows.Models

### Community 239 - "Entity (Community 239)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildCreds(), BuildFactory()

### Community 240 - "Entity (Community 240)"
Cohesion: 0.67
Nodes (3): HttpResponseBodyLoggingHandler.cs, if(), TryLogAsync()

### Community 238 - "Entity (Community 238)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, WorkflowContextKeys.cs, XPoster.Workflows.Models

### Community 231 - "Entity (Community 231)"
Cohesion: 1.00
Nodes (3): XPoster.Models, SlotScheduleOptions.cs, SlotScheduleOptions.cs

### Community 218 - "Entity (Community 218)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, foreach(), if()

### Community 230 - "Entity (Community 230)"
Cohesion: 1.00
Nodes (3): TagReplacementOptions.cs, TagReplacementOptions.cs, XPoster.Models

### Community 229 - "Entity (Community 229)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, if(), DispatchAsync()

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, AiProvider.cs, XPoster.Contracts

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): XCredentials.cs, XCredentials.cs, XPoster.Credentials

### Community 222 - "Entity (Community 222)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, InstagramCredentials.cs, XPoster.Credentials

### Community 220 - "Entity (Community 220)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, XPoster.Contracts, ContainerStatus.cs

### Community 227 - "Entity (Community 227)"
Cohesion: 1.00
Nodes (3): MediaType.cs, XPoster.Workflows.Models, MediaType.cs

### Community 228 - "Entity (Community 228)"
Cohesion: 0.67
Nodes (3): InSender.cs, InSender(), if()

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, FacebookCredentials.cs, XPoster.Credentials

### Community 226 - "Entity (Community 226)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 225 - "Entity (Community 225)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, XPoster.Models, BlobStorageOptions.cs

### Community 248 - "Entity (Community 248)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

### Community 247 - "Entity (Community 247)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

