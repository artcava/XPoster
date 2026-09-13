# Graph Report - XPoster  (2026-09-13)

## Summary
- 1953 nodes · 3309 edges · 237 communities detected
- Extraction: 100% EXTRACTED · 0% INFERRED · 0% AMBIGUOUS

## God Nodes (most connected - your core abstractions)
1. `XPoster.Tests.SenderPlugins` - 2 edges
2. `XPoster.Services` - 2 edges
3. `XPoster.Tests.Models` - 2 edges
4. `AiImageNodeTests` - 2 edges
5. `FbSenderSendAsyncTests` - 2 edges
6. `XPoster.Workflows.Nodes` - 2 edges
7. `XPoster.Workflows.Nodes` - 2 edges
8. `TimeProviderTests` - 2 edges
9. `XPoster.Tests.Providers` - 2 edges
10. `XPoster.SenderPlugins` - 2 edges

## Surprising Connections (you probably didn't know these)
- None detected - all connections are within the same source files.

## Communities

### Community 0 - "Entity (Community 0)"
Cohesion: 0.08
Nodes (49): AiServiceHelperTests.cs, AiServiceHelperTests.cs, ParseImageResponseAsync_AzureFoundry_UrlFallback_DownloadFails_ReturnsEmptyArray(), ParseImageResponseAsync_AzureFoundry_UrlFallback_AllowedOrigin_ReturnsDownloadedBytes(), ParseImageResponseAsync_AzureFoundry_MissingDataArray_ReturnsEmptyArray(), AiServiceHelperTests, ParseImageResponseAsync_OpenAi_EmptyB64JsonValue_ReturnsEmptyArray(), ParseImageResponseAsync_FalAi_MissingUrlProperty_ReturnsEmptyArray() (+41 more)

### Community 1 - "Entity (Community 1)"
Cohesion: 0.10
Nodes (41): AzureFoundryServiceTests.cs, AzureFoundryServiceTests.cs, GenerateImageAsync_RequestBodyContainsModelFromOptions(), GenerateImageAsync_PostsToFoundryImagesGenerationsEndpoint(), GenerateImageAsync_WhenApiReturnsNonSuccess_ReturnsEmptyByteArray(), GenerateImageAsync_RequestBodyContainsSizeAndQuantityFromRequest(), GenerateImageAsync_WhenApiReturnsValidResponse_ReturnsByteArray(), GenerateImageAsync_WhenApiReturnsTooManyRequests_ReturnsEmptyByteArray() (+33 more)

### Community 2 - "Entity (Community 2)"
Cohesion: 0.11
Nodes (36): OpenAiServiceTests.cs, OpenAiServiceTests.cs, GenerateImageAsync_WhenPromptIsEmpty_LogsWarning(), GenerateImageAsync_WhenHttpRequestExceptionThrown_LogsError(), GenerateImageAsync_WhenHttpRequestExceptionThrown_ReturnsEmptyArray(), GenerateTextAsync_ReplacesInputTextLabelInUserPromptTemplate(), GenerateImageAsync_WhenPromptIsWhitespace_ReturnsEmptyArrayWithoutCallingApi(), GenerateImageAsync_WhenResponseBodyIsMalformedJson_ReturnsEmptyArray() (+28 more)

### Community 4 - "Entity (Community 4)"
Cohesion: 0.12
Nodes (32): DryRunSenderTests.cs, DryRunSenderTests.cs, SendAsync_WithNullPost_LogsWarning(), SendAsync_WithImageAttached_ReturnsTrueAndLogsImagePresent(), SendAsync_WithNullContent_StillReturnsTrueWhenKeyPresent(), SendAsync_WithImageBytes_ReturnsTrue(), SendAsync_WhenKeyWhitespace_ReturnsFalse(), SendAsync_DoesNotCallAnyOutboundSocialApi() (+24 more)

### Community 3 - "Entity (Community 3)"
Cohesion: 0.06
Nodes (32): AiServiceHelperImageTests.cs, return(), Parse_UnsupportedProvider_ReturnsEmpty(), Parse_UnsupportedProvider_LogsError(), Parse_Returns429_ReturnsEmpty(), Parse_FalAi_MissingUrlProperty_ReturnsEmpty(), Parse_FalAi_EmptyUrl_ReturnsEmpty(), Parse_FalAi_MissingImagesProperty_ReturnsEmpty() (+24 more)

### Community 5 - "Entity (Community 5)"
Cohesion: 0.14
Nodes (29): OptionsExtensionsTests.cs, OptionsExtensionsTests.cs, AddOpenAiOptions_BindsOptionsFromCorrectSection(), AddFalAiOptions_RegistersValidator(), AddFalAiOptions_BindsOptionsFromCorrectSection(), AddDeepSeekOptions_RegistersValidator(), AddPerplexityOptions_RegistersValidator(), AddOpenAiOptions_RegistersValidator() (+21 more)

### Community 6 - "Entity (Community 6)"
Cohesion: 0.14
Nodes (28): PerplexityServiceTests.cs, PerplexityServiceTests.cs, GenerateTextAsync_WhenApiReturns429_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString(), GenerateTextAsync_WhenApiReturnsNonSuccess_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesArrayIsEmpty_ReturnsEmptyString(), XPoster.Tests.Services, PerplexityServiceTests (+20 more)

### Community 7 - "Entity (Community 7)"
Cohesion: 0.15
Nodes (26): FbSenderTests.cs, FbSenderTests.cs, MessageMaxLength_Returns3000(), FbSender(), FbSenderTests(), FbSender_ImplementsISender(), Constructor_WithNullFactory_ThrowsArgumentNullException(), Constructor_InitializesCorrectly() (+18 more)

### Community 9 - "Entity (Community 9)"
Cohesion: 0.16
Nodes (25): DeepSeekServiceTests.cs, DeepSeekServiceTests.cs, XPoster.Tests.Services, ChatCompletionJson(), BuildService(), GenerateTextAsync_WhenResponseFitsWithinMaxOutputLength_ReturnsSingleCallResult(), GenerateTextAsync_WhenChoicesIsNull_ForImagePromptRole_ReturnsEmptyString(), GenerateTextAsync_WhenChoicesIsNull_ReturnsEmptyString() (+17 more)

### Community 8 - "Entity (Community 8)"
Cohesion: 0.16
Nodes (25): NodeParameterExtractorTests.cs, NodeParameterExtractorTests.cs, GetParameter_ReturnsDefault_WhenKeyMissing(), GetParameter_MalformedJson_ForList_ReturnsEmptyOrNull(), GetParameter_MalformedJsonArrayString_FallsBackToString(), GetParameter_PlainString_StillConverts(), GetProvider_UsesProvidedDefault_WhenMissing(), GetProvider_ParsesValidName_CaseInsensitive() (+17 more)

### Community 11 - "Entity (Community 11)"
Cohesion: 0.19
Nodes (21): XSenderTests.cs, XSenderTests.cs, SendAsync_WithBlankContent_ReturnsFalseAndLogsWarning(), SendAsync_TextPost_WhenApiSucceeds_ReturnsTrueAndLogsTweetId(), SendAsync_WhenConnectionFails_ReturnsFalseAndLogsError(), SendAsync_WhenApiReturns402_ReturnsFalseAndLogsError(), XPoster.Tests.SenderPlugins, XSenderTests (+13 more)

### Community 10 - "Entity (Community 10)"
Cohesion: 0.10
Nodes (21): WorkflowExecutionEngineTests.cs, Diamond(), Cyclic(), ExecuteAsync(), Execute_NodeFailure_StopsExecution_AndReturnsError(), Execute_PowerLawChain_AcquireThenBuildThenFanOut_StoresOutputs(), Execute_UnregisteredNodeType_ReturnsFailure(), WorkflowExecutionEngineTests (+13 more)

### Community 16 - "Entity (Community 16)"
Cohesion: 0.22
Nodes (18): AiServiceHelperChatPayloadTests.cs, AiServiceHelperChatPayloadTests.cs, BuildChatPayload_ForwardsTemperature(), BuildChatPayload_InterpolatesMaxCharsInSystemMessage(), BuildChatPayload_MessagesContainsTwoEntries(), BuildChatPayload_SubstitutesCustomLabelInUserMessage(), BuildChatPayload_SecondMessageRoleIsUser(), BuildChatPayload_ForwardsModelName() (+10 more)

### Community 12 - "Entity (Community 12)"
Cohesion: 0.22
Nodes (18): WorkflowContextTests.cs, WorkflowContextTests.cs, ConcurrentSetData_DoesNotThrow(), ConcurrentReadWrite_DoesNotThrow(), catch(), lock(), GetData_ThrowsOnTypeMismatch(), HasData_ReturnsFalse_WhenKeyMissing() (+10 more)

### Community 15 - "Entity (Community 15)"
Cohesion: 0.22
Nodes (18): AiProviderOptionsAbstractionTests.cs, AiProviderOptionsAbstractionTests.cs, AzureFoundryOptions_ModelCatalog_ExposesTextAndImage(), AzureFoundryOptions_ImplementsIAiProviderOptions(), AiProviderOptionsAbstractionTests, XPoster.Tests.Models, OpenAiOptions_ImplementsIAiProviderOptions(), PerplexityOptions_ImplementsIAiProviderOptions() (+10 more)

### Community 14 - "Entity (Community 14)"
Cohesion: 0.22
Nodes (18): IgSenderImageFlowTests.cs, IgSenderImageFlowTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WhenJsonResponseMissingIdProperty_ReturnsFalse(), NormalizeImage_WithValidPng_ReturnsJpegBytes(), SendAsync_WhenBlobUploadSucceeds_CreatesMediaContainerWithCorrectSasUrl(), return(), SendAsync_WhenJsonResponseIdIsEmpty_ReturnsFalse() (+10 more)

### Community 13 - "Entity (Community 13)"
Cohesion: 0.22
Nodes (18): FeedServiceTests.cs, FeedServiceTests.cs, new(), SendAsync(), XPoster.Tests.Services, GetFeedsAsync_ReturnsEmpty_WhenFeedIsInvalidXml(), GetFeedsAsync_FetchesAndCachesFeeds_WhenCacheMissAndHttpSucceeds(), GetFeedsAsync_FiltersOutItemsOutsideDateRange() (+10 more)

### Community 19 - "Entity (Community 19)"
Cohesion: 0.23
Nodes (17): WorkflowServiceCollectionExtensionsTests.cs, WorkflowServiceCollectionExtensionsTests.cs, InMemory(), AddWorkflows_WithNoTerminalNode_ThrowsInvalidOperationException(), BuildProvider(), AddWorkflows_WithMultipleTerminalNodes_ThrowsInvalidOperationException(), AddWorkflows_WithValidWorkflow_DoesNotThrow(), ConfigurationBuilder() (+9 more)

### Community 18 - "Entity (Community 18)"
Cohesion: 0.23
Nodes (17): PromptRequestTests.cs, PromptRequestTests.cs, PromptRequest_ValueEquality_DifferentValues_AreNotEqual(), XPoster.Tests.Models, PromptRequest_ValueEquality_SameValues_AreEqual(), PromptRequestTests, PromptRequest_Temperature_AcceptsZeroAndOne(), ImagePromptRequest_IsImmutable_AfterConstruction() (+9 more)

### Community 17 - "Entity (Community 17)"
Cohesion: 0.23
Nodes (17): MetaPublishingServiceTests.cs, MetaPublishingServiceTests.cs, XPoster.Tests.Services, PublishContainerAsync_WhenOk_ReturnsPublishId(), PublishContainerAsync_WithWhitespaceCreationId_ThrowsArgumentException(), PublishContainerAsync_WhenResponseBodyIsNull_ThrowsJsonException(), PublishContainerAsync_WhenRateLimited_Throws(), PublishContainerAsync_WhenCancelled_ThrowsTaskCanceledException() (+9 more)

### Community 22 - "Entity (Community 22)"
Cohesion: 0.12
Nodes (16): WorkflowDefinitionValidatorTests.cs, ValidateTerminalNodeContract_UnresolvableTerminalType_ReturnsNull(), WorkflowDefinition(), WorkflowDefinitionValidatorTests, XPoster.Tests.Workflows.Engine, ValidateTerminalNodeContract_TerminalDoesNotImplementContract_ReturnsError(), ValidateStructural_EmptyNodes_ReturnsNull(), ValidateStructural_MultipleTerminalNodes_ReturnsError() (+8 more)

### Community 20 - "Entity (Community 20)"
Cohesion: 0.24
Nodes (16): ConfigurationSlotProfileProviderTests.cs, ConfigurationSlotProfileProviderTests.cs, new(), GetProfiles_Should_SkipSlot_WhenNoValidSendersRemain(), GetProfiles_Should_SkipUnknownSenders_ButKeepValidOnes(), GetProfiles_Should_SkipSlot_WithNoSenders(), GetProfiles_Should_SkipSlot_WithNoWorkflowKey(), GetProfiles_Should_OrderSlotsByHour() (+8 more)

### Community 21 - "Entity (Community 21)"
Cohesion: 0.24
Nodes (16): InMemoryContainerStateStoreTests.cs, InMemoryContainerStateStoreTests.cs, SaveAsync_WithValidInputs_StoresPendingEntry(), SaveAsync_WithNullCreationId_ThrowsArgumentNullException(), InMemoryContainerStateStoreTests, SaveAsync_WithEmptyOrWhitespaceBlobName_ThrowsArgumentException(), SaveAsync_WithNullBlobName_ThrowsArgumentNullException(), SaveAsync_WithEmptyOrWhitespaceCreationId_ThrowsArgumentException() (+8 more)

### Community 26 - "Entity (Community 26)"
Cohesion: 0.26
Nodes (15): BlobStorageServiceTests.cs, BlobStorageServiceTests.cs, BlobStorageService(), CreateSut(), Constructor_WhenContainerNameIsEmpty_UsesDefaultName(), BlobStorageServiceTests, DeleteAsync_WhenBlobDoesNotExist_LogsDebugAndDoesNotThrow(), DeleteAsync_WhenBlobExists_DeletesSuccessfully() (+7 more)

### Community 23 - "Entity (Community 23)"
Cohesion: 0.26
Nodes (15): MaskUrlTelemetryProcessorTests.cs, MaskUrlTelemetryProcessorTests.cs, Initialize_WhenFacebookUrlHasAccessToken_TokenIsMasked(), Initialize_WhenDataIsEmpty_DoesNotThrow(), Initialize_WhenAccessTokenAlreadyMasked_DoesNotDoubleEncode(), Initialize_WhenDataIsNull_DoesThrow(), Initialize_WhenFacebookDataIsMalformedUrl_DataRemainsUnchanged(), Initialize_WhenDependencyTypeIsNotHttp_DoesNotModifyData() (+7 more)

### Community 25 - "Entity (Community 25)"
Cohesion: 0.26
Nodes (15): IgSenderResilienceTests.cs, IgSenderResilienceTests.cs, BuildSender(), PostWithoutImage(), IgSender(), PostWithImage(), IgSenderResilienceTests, new() (+7 more)

### Community 24 - "Entity (Community 24)"
Cohesion: 0.26
Nodes (15): AddAiProviderOptionsTests.cs, AddAiProviderOptionsTests.cs, BuildAllProvidersConfig(), ConfigurationBuilder(), XPoster.Tests.Extensions, AddAiProviderOptions_ReturnsSameServiceCollection(), AddAiProviderOptions_BindsPerplexityOptions_FromCorrectSection(), AddAiProviderOptions_RegistersAllFiveOptionTypes() (+7 more)

### Community 29 - "Entity (Community 29)"
Cohesion: 0.14
Nodes (14): WorkflowOrchestratorTests.cs, WorkflowOrchestratorTests, ProduceImage_IsTrue_WhenWorkflowHasAiImageNode(), ProduceImage_Set_ThrowsNotSupported(), Properties_AreConfigured(), return(), static(), OrchestrateAsync_ReturnsPostMap_OnSuccess() (+6 more)

### Community 30 - "Entity (Community 30)"
Cohesion: 0.27
Nodes (14): ModelsTests.cs, ModelsTests.cs, Message_CanBeCreated_WithContent(), ImageData_CanBeCreated_WithUrl(), AIResponse_CanBeCreated_WithChoices(), Choice_CanBeCreated_WithMessage(), OpenAIImageResponse_CanBeCreated_WithData(), Post_Firm_ContainsExpectedHashtags() (+6 more)

### Community 27 - "Entity (Community 27)"
Cohesion: 0.27
Nodes (14): XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction.cs, XPosterContainerPollingFunction(), XPoster, PollPendingContainersAsync(), TryDeleteBlobAsync(), ProcessContainerAsync(), switch() (+6 more)

### Community 28 - "Entity (Community 28)"
Cohesion: 0.14
Nodes (14): FanOutSendNodeTests.cs, XPoster.Tests.Workflows.Nodes, FanOutSendNodeTests, static(), return(), WorkflowNodeInput(), Input(), Execute_TwoSenders_ResummarisesForSmallSenderAndKeepsVariantForWideSender() (+6 more)

### Community 35 - "Entity (Community 35)"
Cohesion: 0.29
Nodes (13): FalAiOptionsValidatorTests.cs, FalAiOptionsValidatorTests.cs, Validate_WhitespaceModelId_Fails(), XPoster.Tests.Models, ValidOptions(), Validate_ValidOptions_Succeeds(), FalAiOptionsValidatorTests, Validate_MissingApiKey_Fails() (+5 more)

### Community 36 - "Entity (Community 36)"
Cohesion: 0.15
Nodes (13): AiImageNodeTests.cs, Execute_ReturnsMediaAttachment_OnSuccess(), AiImageNodeTests, Execute_ReturnsFailure_WhenRequired_AndImageMissing(), Execute_ReturnsSoftFailure_WhenRequiredFalse_AndImageMissing(), return(), Execute_Throws_WhenValidProviderNotRegistered(), if() (+5 more)

### Community 33 - "Entity (Community 33)"
Cohesion: 0.15
Nodes (13): FalAiImageServiceTests.cs, GenerateImageAsync_ReturnsNonSuccess_ReturnsEmptyArray(), FalImageJson(), GenerateImageAsync_Returns429_ReturnsEmptyArray(), GenerateImageAsync_MissingUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithUnsafeChars_PercentEncodesInRequestUri(), GenerateImageAsync_EmptyImagesArray_ReturnsEmptyArray(), GenerateImageAsync_EmptyPrompt_ReturnsEmptyArray() (+5 more)

### Community 31 - "Entity (Community 31)"
Cohesion: 0.29
Nodes (13): AiModelCatalogTests.cs, AiModelCatalogTests.cs, GetRequired_Throws_WhenNotSupported(), AiModelCatalogTests, GetRequired_ReturnsModelName_WhenSupported(), Empty_SupportsNoModelClass(), Constructor_NullDictionary_Throws(), Constructor_ExcludesNullOrWhitespaceEntries() (+5 more)

### Community 32 - "Entity (Community 32)"
Cohesion: 0.15
Nodes (13): XApiClientTests.cs, UploadMediaAsync_EmptyMedia_ThrowsArgumentException(), CreateTweetAsync_WhenApiReturns402_ThrowsXApiExceptionWithParsedDetails(), foreach(), CreateTweetAsync_WithText_ReturnsTweetId(), CreateTweetAsync_WithMediaId_SerializesMediaIdsInPayload(), CreateTweetAsync_WhenBodyCarriesErrorsArray_ThrowsXApiException(), UploadMediaAsync_WhenAppendRejected_ThrowsXApiException() (+5 more)

### Community 34 - "Entity (Community 34)"
Cohesion: 0.29
Nodes (13): LocalOverrideTimeProviderTests.cs, LocalOverrideTimeProviderTests.cs, GetCurrentTime_WhenForceHourIsAbsent_FallsBackToUtcHour(), BuildProvider(), Constructor_AlwaysEmitsDevOverrideWarning(), XPoster.Tests.Providers, GetCurrentTime_WhenForceHourIsNonNumeric_FallsBackToUtcHour(), LocalOverrideTimeProviderTests (+5 more)

### Community 37 - "Entity (Community 37)"
Cohesion: 0.15
Nodes (13): InSenderTests.cs, SendAsync_TextOnly_WithPersonCode_UsesPersonUrn(), XPoster.Tests.SenderPlugins, SendAsync_WhenOrgIdIsAbsentAndOwnerIsSet_UsesPersonUrn(), SendAsync_WhenOrgIdIsSet_UsesOrganizationUrn(), SendAsync_WithImage_WhenRegisterUploadFails_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), InSender_ImplementsISender() (+5 more)

### Community 45 - "Entity (Community 45)"
Cohesion: 0.17
Nodes (12): FalAiImageServiceTests.cs, GenerateImageAsync_WhenImageDownloadFails_HttpRequestException_LogsError(), GenerateImageAsync_WhitespacePrompt_ReturnsEmptyArray(), MakeHandlerMock(), MakeRequest(), GenerateImageAsync_MissingImagesProperty_ReturnsEmptyArray(), GenerateImageAsync_EmptyUrlProperty_ReturnsEmptyArray(), GenerateImageAsync_ModelIdWithMultipleSegments_PreservesSlashesInUri() (+4 more)

### Community 42 - "Entity (Community 42)"
Cohesion: 0.17
Nodes (12): OrchestratorFactoryTests.cs, Resolve_Should_ReturnWorkflowOrchestrator_ForAnyConfiguredSlot(), Resolve_Should_ResolveAllSenders_ForMultiPlatformProfile(), foreach(), Resolve_Should_ResolveKeyedSender_ForEachSupportedPlatform(), Resolve_ForMissingContextKey_ReturnsNoOrchestrator(), NoOrchestrator_SupportedPlatforms_IsEmpty(), Resolve_Should_ReturnNoOrchestrator_WhenNoProfileMatchesCurrentHour() (+4 more)

### Community 38 - "Entity (Community 38)"
Cohesion: 0.17
Nodes (12): InSenderTests.cs, SendAsync_WhenNeitherOrgIdNorOwnerCodeSet_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalseAndLogsWarning(), SendAsync_WithImageBytes_TriesHttpCall_ReturnsFalse(), InSender(), SendAsync_WhenBothOrgIdAndOwnerAreAbsent_ThrowsAndReturnsFalse(), InSenderTests(), Platform_ReturnsLinkedIn() (+4 more)

### Community 41 - "Entity (Community 41)"
Cohesion: 0.17
Nodes (12): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsError_MarksFailedAndCleansUp(), XPoster.Tests, XPosterContainerPollingFunctionTests, RunAsync_WhenStatusIsUnknown_LogsWarningAndSkips(), RunAsync_WhenStatusIsInProgress_SkipsContainer(), RunAsync_WhenUnexpectedExceptionThrown_LogsErrorAndRethrows(), RunAsync_WhenCancelledDuringForEach_StopsGracefully() (+4 more)

### Community 40 - "Entity (Community 40)"
Cohesion: 0.32
Nodes (12): AzureFoundryService.cs, AzureFoundryService.cs, while(), XPoster.Services, var(), catch(), if(), GenerateTextAsync() (+4 more)

### Community 44 - "Entity (Community 44)"
Cohesion: 0.32
Nodes (12): ConfigurationTagReplacementProviderTests.cs, ConfigurationTagReplacementProviderTests.cs, GetReplacements_Should_ReturnReadOnlyDictionary(), ConfigurationTagReplacementProviderTests, Constructor_Should_Throw_When_OptionsIsNull(), foreach(), GetReplacements_Should_ReturnConfiguredReplacements_When_OptionsContainsEntries(), ConfigurationTagReplacementProvider() (+4 more)

### Community 43 - "Entity (Community 43)"
Cohesion: 0.17
Nodes (12): XApiClient.cs, CreateTweetAsync(), BuildSignedRequest(), catch(), ArgumentException(), XPoster.SenderPlugins, for(), HasErrorPayload() (+4 more)

### Community 39 - "Entity (Community 39)"
Cohesion: 0.32
Nodes (12): ConfigurationStepOptionsResolverTests.cs, ConfigurationStepOptionsResolverTests.cs, if(), foreach(), ConfigurationStepOptionsResolverTests, BuildConfig(), Resolve_BindsMaxOutputLength_WhenPresent(), Resolve_ReturnsStepOptions_WhenSectionExists() (+4 more)

### Community 46 - "Entity (Community 46)"
Cohesion: 0.35
Nodes (11): InSenderResilienceTests.cs, InSenderResilienceTests.cs, InSender(), BuildSender(), InSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse(), SendAsync_WhenLinkedInReturns429ThenSuccess_ReturnsTrue(), SendAsync_WhenLinkedInReturns503_ReturnsFalseAndLogsError() (+3 more)

### Community 50 - "Entity (Community 50)"
Cohesion: 0.35
Nodes (11): AiProviderServiceCollectionExtensionsTests.cs, AiProviderServiceCollectionExtensionsTests.cs, AddXPosterAiProviders_RegistersExpectedNumberOfKeyedServices(), AddXPosterAiProviders_RegistersDeepSeek_AsTextOnly(), AddXPosterAiProviders_RegistersAzureFoundry_AsTextAndImageProvider(), AddXPosterAiProviders_RegistersOpenAi_AsTextAndImageProvider(), AddXPosterAiProviders_ReturnsSameServiceCollection(), AddXPosterAiProviders_RegistersPerplexity_AsTextOnly() (+3 more)

### Community 49 - "Entity (Community 49)"
Cohesion: 0.18
Nodes (11): IgSenderTests.cs, new(), MessageMaxLength_Returns2200(), XPoster.Tests.SenderPlugins, Platform_ReturnsInstagram(), Constructor_WithNullHttpClientFactory_ThrowsArgumentNullException(), Constructor_WithNullContainerStateStore_ThrowsArgumentNullException(), BuildSender() (+3 more)

### Community 47 - "Entity (Community 47)"
Cohesion: 0.35
Nodes (11): ScheduledOrchestrationProfileTests.cs, ScheduledOrchestrationProfileTests.cs, XPoster.Tests.Models, Constructor_Should_PreserveOrderOfSenderPlatforms(), Constructor_Should_SetAllFields(), OrchestratorContextKey_Should_BeSet_WhenProvided(), TwoSlotsWithSameOrchestratorType_Should_CarryIndependentContextKeys(), typeof() (+3 more)

### Community 48 - "Entity (Community 48)"
Cohesion: 0.35
Nodes (11): XOAuth1SignerTests.cs, XOAuth1SignerTests.cs, XOAuth1SignerTests, XPoster.Tests.SenderPlugins, ComputeSignatureBaseString_PhotoExample_ReturnsExpectedBaseString(), BuildAuthorizationHeader_PhotoExample_ContainsOAuthParameters(), ComputeSignature_PhotoExample_ReturnsExpectedBase64(), BuildCredentials() (+3 more)

### Community 51 - "Entity (Community 51)"
Cohesion: 0.35
Nodes (11): XOAuth1Signer.cs, XOAuth1Signer.cs, ComputeSignatureBaseString(), XPoster.SenderPlugins, GetBaseUri(), foreach(), if(), PercentEncode() (+3 more)

### Community 57 - "Entity (Community 57)"
Cohesion: 0.38
Nodes (10): XFunctionTests.cs, XFunctionTests.cs, Run_Should_LogError_When_PostAsync_ReturnsFalse(), Run_Should_LogError_When_OrchestrateAsync_ReturnsEmptyDictionary(), Run_Should_GenerateAndSendMessage_When_GeneratorIsEnabled(), Run_Should_DoNothing_When_GeneratorIsDisabled(), Run_Should_Rethrow_When_Factory_Throws(), XFunctionTests() (+2 more)

### Community 56 - "Entity (Community 56)"
Cohesion: 0.38
Nodes (10): IgSenderSendAsyncTests.cs, IgSenderSendAsyncTests.cs, SendAsync_WithNoImage_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WithCaptionExceedingMaxLength_TruncatesCaption(), BuildSender(), IgSenderSendAsyncTests (+2 more)

### Community 54 - "Entity (Community 54)"
Cohesion: 0.38
Nodes (10): FbSenderSendAsyncTests.cs, FbSenderSendAsyncTests.cs, SendAsync_WithNullPost_ReturnsFalseAndLogsWarning(), SendAsync_WithNullImage_PublishesTextOnly_ReturnsTrue(), BuildFactory(), BuildCreds(), SendAsync_WithEmptyImage_PublishesTextOnly_ReturnsTrue(), FbSenderSendAsyncTests (+2 more)

### Community 53 - "Entity (Community 53)"
Cohesion: 0.38
Nodes (10): FbSender.cs, FbSender.cs, XPoster.SenderPlugins, catch(), PublishTextOnlyAsync(), FbSender(), SendAsync(), PublishPhotoAsync() (+2 more)

### Community 58 - "Entity (Community 58)"
Cohesion: 0.38
Nodes (10): MetaPublishingService.cs, MetaPublishingService.cs, HttpRequestException(), catch(), GetContainerStatusAsync(), GetApiVersion(), MetaPublishingService(), PublishContainerAsync() (+2 more)

### Community 55 - "Entity (Community 55)"
Cohesion: 0.38
Nodes (10): PerplexityOptionsValidatorTests.cs, PerplexityOptionsValidatorTests.cs, Validate_WhenEndpointIsEmpty_ReturnsFailed(), Validate_WithMultipleInvalidFields_ReturnsAllFailures(), PerplexityOptionsValidatorTests, Validate_WhenTextModelNameIsEmpty_ReturnsFailed(), Validate_WhenApiKeyIsEmpty_ReturnsFailed(), Validate_WithValidOptions_ReturnsSuccess() (+2 more)

### Community 52 - "Entity (Community 52)"
Cohesion: 0.38
Nodes (10): NoOrchestratorTests.cs, NoOrchestratorTests.cs, SupportedPlatforms_IsEmpty(), SendIt_IsAlwaysFalse(), OrchestrateAsync_ReturnsEmptyList(), Name_IsNoOrchestrator(), Build(), SendIt_Set_ThrowsNotImplementedException() (+2 more)

### Community 71 - "Entity (Community 71)"
Cohesion: 0.22
Nodes (9): BaseOrchestratorTests.cs, PostAsync_SkipsNullPost_ReturnsFalse(), PostAsync_ReturnsTrue_When_AllConditionsMet(), PostAsync_ReturnsFalse_WhenOneSenderFails(), PostAsync_ReturnsFalse_When_SendIt_IsFalse(), PostAsync_ReturnsFalse_WhenSenderListIsEmpty(), PostAsync_DoesNotLogWarning_When_ProduceImage_IsTrue_And_Image_IsPresent(), PostAsync_ReturnsFalse_When_Content_IsWhiteSpace() (+1 more)

### Community 70 - "Entity (Community 70)"
Cohesion: 0.42
Nodes (9): AiModelCatalog.cs, AiModelCatalog.cs, Supports(), InvalidOperationException(), TryGet(), XPoster.Models, GetRequired(), AiModelCatalog() (+1 more)

### Community 72 - "Entity (Community 72)"
Cohesion: 0.22
Nodes (9): XPosterContainerPollingFunctionTests.cs, RunAsync_WhenStatusIsFinished_PublishesAndCleansUp(), RunAsync_WhenBlobDeleteFails_StillUpdatesStatus(), RunAsync_WhenCancelled_StopsGracefully(), RunAsync_WhenPublishFails_MarksFailedAndCleansUp(), CreateTimerInfo(), PendingContainer(), RunAsync_WhenStatusIsExpired_MarksFailedAndCleansUp() (+1 more)

### Community 69 - "Entity (Community 69)"
Cohesion: 0.42
Nodes (9): HttpClientExtensionsTests.cs, HttpClientExtensionsTests.cs, AddHttpClients_CanCreateAllExpectedNamedClients(), XPoster.Tests.Extensions, AddHttpClients_RegistersExpectedNamedClients(), AddHttpClients_ReturnsSameServiceCollection(), AddHttpClients_RegistersIHttpClientFactory(), HttpClientExtensionsTests (+1 more)

### Community 60 - "Entity (Community 60)"
Cohesion: 0.42
Nodes (9): AcquireCryptoValueNodeTests.cs, AcquireCryptoValueNodeTests.cs, XPoster.Tests.Workflows.Nodes, Execute_UsesDefaultSymbol_WhenNotProvided(), WorkflowNodeInput(), Input(), AcquireCryptoValueNodeTests(), Execute_ReturnsCryptoValue_WhenSymbolParameterProvided() (+1 more)

### Community 59 - "Entity (Community 59)"
Cohesion: 0.22
Nodes (9): FbSenderImageFlowTests.cs, SendAsync_WhenImageNormalizationFails_FallsBackToTextOnly(), InvalidImageBytes(), FbSenderImageFlowTests, HttpRequestException(), BuildFactory(), BuildCreds(), XPoster.Tests.SenderPlugins (+1 more)

### Community 62 - "Entity (Community 62)"
Cohesion: 0.42
Nodes (9): PollyIntegrationTestBase.cs, PollyIntegrationTestBase.cs, XPoster.Tests.Integration, HttpResponseMessage(), var(), BuildProviderWithHandler(), BuildDelayedHandler(), params() (+1 more)

### Community 68 - "Entity (Community 68)"
Cohesion: 0.42
Nodes (9): FacebookResiliencePipelineTests.cs, FacebookResiliencePipelineTests.cs, Polly_Facebook_AttemptTimeout_CancelsSlowRequest(), Polly_Facebook_RetriesOn429_AndEventuallySucceeds(), catch(), XPoster.Tests.Integration, Polly_Facebook_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_Facebook_OnRetry_LogEntryIsEmitted() (+1 more)

### Community 61 - "Entity (Community 61)"
Cohesion: 0.42
Nodes (9): CryptoServiceTests.cs, CryptoServiceTests.cs, MakeService(), CryptoService(), GetCryptoValue_ReturnsZero_AndLogsError_OnException(), CryptoServiceTests, GetCryptoValue_ReturnsParsedValue_WhenNumericString(), XPoster.Tests.Services (+1 more)

### Community 67 - "Entity (Community 67)"
Cohesion: 0.42
Nodes (9): WorkflowExecutionEngine.cs, WorkflowExecutionEngine.cs, WorkflowExecutionResult(), if(), ExecuteAsync(), foreach(), WorkflowExecutionEngine(), while() (+1 more)

### Community 66 - "Entity (Community 66)"
Cohesion: 0.42
Nodes (9): RSSFeedTests.cs, RSSFeedTests.cs, RSSFeedTests, XPoster.Tests.Models, RSSFeed_DefaultPublishDateIsMinValue(), RSSFeed_RecordEquality_DifferentValues_AreNotEqual(), RSSFeed_CanSetPublishDate(), RSSFeed_CanCreateWithRequiredProperties() (+1 more)

### Community 65 - "Entity (Community 65)"
Cohesion: 0.42
Nodes (9): XSenderResilienceTests.cs, XSenderResilienceTests.cs, SendAsync_WhenPostIsNull_ReturnsFalseAndLogsWarning(), XPoster.Tests.SenderPlugins, SendAsync_WhenTextTweetReturns402_ReturnsFalseAndLogsError(), XSenderResilienceTests, SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalseAndLogsError(), SendAsync_WhenContentIsBlank_ReturnsFalseAndLogsWarning() (+1 more)

### Community 64 - "Entity (Community 64)"
Cohesion: 0.22
Nodes (9): InSender.cs, InvalidOperationException(), ResolveAuthorUrn(), XPoster.SenderPlugins, using(), SendAsync(), catch(), generatePayLoad() (+1 more)

### Community 63 - "Entity (Community 63)"
Cohesion: 0.22
Nodes (9): FbSenderResilienceTests.cs, HttpResponseMessage(), SendAsync_WhenTextPublishReturns200WithoutId_ReturnsFalse(), XPoster.Tests.SenderPlugins, SendAsync_WhenFacebookReturns503_ReturnsFalseAndLogsError(), SendAsync_WhenTextPublishReturns200WithEmptyId_ReturnsFalse(), SendAsync_WhenTextPublishReturns200WithId_ReturnsTrue(), SendAsync_WhenHttpRequestExceptionThrown_ReturnsFalse() (+1 more)

### Community 80 - "Entity (Community 80)"
Cohesion: 0.25
Nodes (8): BaseOrchestratorTests.cs, PostAsync_ReturnsFalse_When_Content_IsEmpty(), PostAsync_DispatchesEachPostToAlignedSender(), PostAsync_LogsWarning_When_ProduceImage_IsTrue_And_Image_IsNull(), BaseOrchestratorTests(), PostAsync_ReturnsFalse_WhenSenderPlatformNotInDictionary(), TestOrchestrator(), PostAsync_ReturnsFalse_When_Sender_ReturnsFalse()

### Community 79 - "Entity (Community 79)"
Cohesion: 0.46
Nodes (8): BlobStorageService.cs, BlobStorageService.cs, BlobUploadResult(), UploadAsync(), DeleteAsync(), if(), XPoster.Services, BlobStorageService()

### Community 88 - "Entity (Community 88)"
Cohesion: 0.46
Nodes (8): FalAiImageService.cs, FalAiImageService.cs, XPoster.Services, GenerateImageAsync(), FalAiImageService(), catch(), if(), GetImageGenerationEndpoint()

### Community 89 - "Entity (Community 89)"
Cohesion: 0.46
Nodes (8): InSenderSendAsyncTests.cs, InSenderSendAsyncTests.cs, XPoster.Tests.SenderPlugins, SendAsync_WithValidPost_CatchesNetworkException_ReturnsFalse(), InSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), SendAsync_WithEmptyContent_ReturnsFalse()

### Community 82 - "Entity (Community 82)"
Cohesion: 0.46
Nodes (8): DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests.cs, DeepSeekOptionsValidatorTests, Validate_AccumulatesAllFailures_WhenMultipleRulesViolated(), Validate_ValidOptions_Succeeds(), XPoster.Tests.Models, ValidOptions(), Validate_MissingRequiredProperties_Fails()

### Community 81 - "Entity (Community 81)"
Cohesion: 0.25
Nodes (8): AiServiceHelper.cs, ParseImageResponseAsync(), XPoster.Services, ExtractOpenAiBytes(), LogAndReturnEmpty(), ExtractFalAiBytesAsync(), BuildChatPayload(), ExtractAzureFoundryBytesAsync()

### Community 83 - "Entity (Community 83)"
Cohesion: 0.46
Nodes (8): FanOutSendNode.cs, FanOutSendNode.cs, if(), foreach(), FanOutSendNode(), ExecuteAsync(), WorkflowNodeResult(), XPoster.Workflows.Nodes

### Community 73 - "Entity (Community 73)"
Cohesion: 0.46
Nodes (8): PostTests.cs, PostTests.cs, Post_CanSetAndGetAllProperties(), Post_DefaultImageIsNull(), Post_EmptyContent_IsAllowed(), XPoster.Tests.Models, Firm_IsNotNullOrEmpty(), PostTests

### Community 74 - "Entity (Community 74)"
Cohesion: 0.25
Nodes (8): BuildPowerLawPostNodeTests.cs, CreateNode(), Execute_OmitsDelta_WhenActualValueZeroOrMissing(), Execute_ComputesFairValueAndAppendsDelta_WhenActualPositive(), Execute_CalculatesCorrectPowerLawValue_ForFixedDate(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, new()

### Community 85 - "Entity (Community 85)"
Cohesion: 0.25
Nodes (8): AiTextNodeTests.cs, Execute_Throws_WhenProviderNameIsUnknown(), AiTextNodeTests, Execute_ReturnsFailure_WhenProviderReturnsEmpty(), static(), WorkflowNodeInput(), XPoster.Tests.Workflows.Nodes, return()

### Community 84 - "Entity (Community 84)"
Cohesion: 0.25
Nodes (8): FetchRssNodeTests.cs, Execute_ReturnsFailure_WhenNoUrlsProvided(), FetchRssNodeTests, foreach(), return(), Execute_ReturnsFailure_WhenNoContentRetrieved(), XPoster.Tests.Workflows.Nodes, static()

### Community 75 - "Entity (Community 75)"
Cohesion: 0.25
Nodes (8): OrchestratorFactoryTests.cs, CreateFactoryWithProfiles(), SetupMocksForOrchestratorFactory(), CreateFactory(), new(), OrchestratorFactoryTests(), WorkflowOrchestrator_SupportedPlatforms_ContainsAllExpectedPlatforms(), WorkflowProfile()

### Community 76 - "Entity (Community 76)"
Cohesion: 0.46
Nodes (8): FetchRssNode.cs, FetchRssNode.cs, FetchRssNode(), ExecuteAsync(), WorkflowNodeResult(), XPoster.Workflows.Nodes, if(), foreach()

### Community 77 - "Entity (Community 77)"
Cohesion: 0.46
Nodes (8): WorkflowContext.cs, WorkflowContext.cs, if(), HasData(), WorkflowContext, XPoster.Workflows.Models, KeyNotFoundException(), SetData()

### Community 86 - "Entity (Community 86)"
Cohesion: 0.46
Nodes (8): CaptureLoggerProvider.cs, CaptureLoggerProvider.cs, XPoster.Tests.Integration, CaptureLoggerProvider(), CaptureLogger(), CreateLogger(), Dispose(), IsEnabled()

### Community 78 - "Entity (Community 78)"
Cohesion: 0.46
Nodes (8): AiProviderExtensionsTests.cs, AiProviderExtensionsTests.cs, GetLabel_KnownProvider_ReturnsDescriptionAttributeValue(), GetLabel_DescriptionMatchesEnumName(), AiProviderExtensionsTests, GetLabel_UnknownProvider_ReturnsFallbackToString(), XPoster.Tests.Contracts, GetLabel_DescriptionDiffersFromEnumName()

### Community 87 - "Entity (Community 87)"
Cohesion: 0.46
Nodes (8): AIResponse.cs, AIResponse.cs, AIResponse, Choice, Message, ImageData, XPoster.Models, OpenAIImageResponse

### Community 90 - "Entity (Community 90)"
Cohesion: 0.52
Nodes (7): XSenderSendAsyncTests.cs, XSenderSendAsyncTests.cs, SendAsync_WithEmptyContent_ReturnsFalse(), SendAsync_WithNullPost_ReturnsFalse(), XSenderSendAsyncTests(), SendAsync_WithWhiteSpaceContent_ReturnsFalse(), XPoster.Tests.SenderPlugins

### Community 96 - "Entity (Community 96)"
Cohesion: 0.52
Nodes (7): XFunction.cs, XFunction.cs, catch(), if(), Run(), XPoster, XFunction()

### Community 97 - "Entity (Community 97)"
Cohesion: 0.52
Nodes (7): XSender.cs, XSender.cs, XPoster.SenderPlugins, SendAsync(), if(), catch(), XSender()

### Community 104 - "Entity (Community 104)"
Cohesion: 0.52
Nodes (7): AiImageNode.cs, AiImageNode.cs, AiImageNode(), if(), WorkflowNodeResult(), XPoster.Workflows.Nodes, ExecuteAsync()

### Community 102 - "Entity (Community 102)"
Cohesion: 0.29
Nodes (7): CredentialsStartupValidator.cs, CredentialsStartupValidator(), Validate(), InvalidOperationException(), XPoster.Credentials, if(), catch()

### Community 103 - "Entity (Community 103)"
Cohesion: 0.29
Nodes (7): OpenAiService.cs, while(), GenerateTextAsync(), XPoster.Services, var(), catch(), GenerateImageAsync()

### Community 101 - "Entity (Community 101)"
Cohesion: 0.52
Nodes (7): IgSender.cs, IgSender.cs, SendAsync(), IgSender(), if(), catch(), XPoster.SenderPlugins

### Community 100 - "Entity (Community 100)"
Cohesion: 0.29
Nodes (7): FbSenderImageFlowTests.cs, CreateValidJpegBytes(), SendAsync_WhenDeleteFails_AfterSuccessfulPhotoPublish_ReturnsTrue(), SendAsync_WithSupportedImage_UploadsPublishesPhotoAndDeletesBlob(), SendAsync_WhenUploadThrows_FallsBackToTextOnly(), if(), HttpResponseMessage()

### Community 91 - "Entity (Community 91)"
Cohesion: 0.52
Nodes (7): WorkflowServiceCollectionExtensions.cs, WorkflowServiceCollectionExtensions.cs, foreach(), if(), XPoster.Workflows.Configuration, InvalidOperationException(), AddWorkflows()

### Community 93 - "Entity (Community 93)"
Cohesion: 0.52
Nodes (7): AiTextNode.cs, AiTextNode.cs, XPoster.Workflows.Nodes, ExecuteAsync(), if(), WorkflowNodeResult(), AiTextNode()

### Community 92 - "Entity (Community 92)"
Cohesion: 0.52
Nodes (7): IContainerStateStore.cs, IContainerStateStore.cs, GetPendingAsync(), UpdateStatusAsync(), XPoster.Contracts, IContainerStateStore, SaveAsync()

### Community 98 - "Entity (Community 98)"
Cohesion: 0.52
Nodes (7): InMemoryContainerStateStore.cs, InMemoryContainerStateStore.cs, XPoster.Services, InMemoryContainerStateStore, SaveAsync(), UpdateStatusAsync(), GetPendingAsync()

### Community 99 - "Entity (Community 99)"
Cohesion: 0.52
Nodes (7): AzureFoundryOptionsValidatorTests.cs, AzureFoundryOptionsValidatorTests.cs, Validate_ValidOptions_Succeeds(), ValidOptions(), AzureFoundryOptionsValidatorTests, XPoster.Tests.Models, Validate_MissingRequiredProperties_Fails()

### Community 105 - "Entity (Community 105)"
Cohesion: 0.29
Nodes (7): ResilienceTestHelpers.cs, StubHttpMessageHandler(), XPoster.Tests.Helpers, var(), CapturedRequest(), if(), BuildSequenceHandler()

### Community 95 - "Entity (Community 95)"
Cohesion: 0.52
Nodes (7): TagReplacementService.cs, TagReplacementService.cs, TagReplacementService(), if(), foreach(), Apply(), XPoster.Services

### Community 94 - "Entity (Community 94)"
Cohesion: 0.29
Nodes (7): OrchestratorFactory.cs, WorkflowOrchestrator(), ResolveSenders(), Resolve(), NoOrchestrator(), catch(), XPoster.Orchestrators

### Community 127 - "Entity (Community 127)"
Cohesion: 0.33
Nodes (6): FetchRssNodeTests.cs, Input(), Execute_ConcatenatesMultipleFeeds(), Execute_CallsFeedServiceForMultipleUrls(), var(), WorkflowNodeInput()

### Community 125 - "Entity (Community 125)"
Cohesion: 0.60
Nodes (6): BuildPowerLawPostNode.cs, BuildPowerLawPostNode.cs, XPoster.Workflows.Nodes, if(), ExecuteAsync(), BuildPowerLawPostNode()

### Community 126 - "Entity (Community 126)"
Cohesion: 0.60
Nodes (6): AcquireCryptoValueNode.cs, AcquireCryptoValueNode.cs, AcquireCryptoValueNode(), WorkflowNodeResult(), XPoster.Workflows.Nodes, ExecuteAsync()

### Community 116 - "Entity (Community 116)"
Cohesion: 0.60
Nodes (6): Program.cs, Program.cs, BlobServiceClient(), Uri(), DefaultAzureCredential(), if()

### Community 114 - "Entity (Community 114)"
Cohesion: 0.60
Nodes (6): TimeProviderTests.cs, TimeProviderTests.cs, GetCurrentTime_ReturnsUtcTime(), GetCurrentTime_ReturnsCurrentDateTime(), TimeProviderTests, XPoster.Tests.Providers

### Community 115 - "Entity (Community 115)"
Cohesion: 0.33
Nodes (6): BuildPowerLawPostNodeTests.cs, Input(), BuildPowerLawPostNodeTests(), Execute_UsesSymbol_ForPostTag(), Execute_DateBeforeGenesis_ReturnsFailure(), if()

### Community 133 - "Entity (Community 133)"
Cohesion: 0.60
Nodes (6): WorkflowDefinitionValidator.cs, WorkflowDefinitionValidator.cs, if(), HasCycle(), foreach(), XPoster.Workflows.Engine

### Community 131 - "Entity (Community 131)"
Cohesion: 0.33
Nodes (6): OrchestratorFactory.cs, OrchestratorFactory(), nameof(), ResolveWorkflowOrchestrator(), if(), CreateEmptyNoOrchestrator()

### Community 132 - "Entity (Community 132)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsTests.cs, AzureFoundryOptionsTests.cs, XPoster.Tests.Models, AzureFoundryOptionsTests, AzureFoundryOptions_DoesNotExpose_ApiVersionProperty(), AzureFoundryOptions_Defaults_AreCorrect()

### Community 108 - "Entity (Community 108)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsValidator.cs, DeepSeekOptionsValidator.cs, XPoster.Models, Validate(), nameof(), if()

### Community 106 - "Entity (Community 106)"
Cohesion: 0.60
Nodes (6): PerplexityOptionsValidator.cs, PerplexityOptionsValidator.cs, nameof(), XPoster.Models, Validate(), if()

### Community 107 - "Entity (Community 107)"
Cohesion: 0.60
Nodes (6): IBlobStorageService.cs, IBlobStorageService.cs, IBlobStorageService, DeleteAsync(), XPoster.Contracts, UploadAsync()

### Community 121 - "Entity (Community 121)"
Cohesion: 0.60
Nodes (6): IMetaPublishingService.cs, IMetaPublishingService.cs, XPoster.Contracts, GetContainerStatusAsync(), IMetaPublishingService, PublishContainerAsync()

### Community 119 - "Entity (Community 119)"
Cohesion: 0.33
Nodes (6): IgSenderTests.cs, Constructor_WithNullCredentials_ThrowsArgumentNullException(), IgSender(), IgSenderTests(), IgSender_ImplementsISender(), Constructor_WithNullBlobStorageService_ThrowsArgumentNullException()

### Community 120 - "Entity (Community 120)"
Cohesion: 0.33
Nodes (6): AiTextNodeTests.cs, Execute_PassesStepOptionsToPromptRequest(), Execute_ReturnsGeneratedText(), Input(), var(), Execute_Throws_WhenValidProviderNotRegistered()

### Community 111 - "Entity (Community 111)"
Cohesion: 0.33
Nodes (6): XApiException.cs, catch(), foreach(), XApiException(), XPoster.SenderPlugins, BuildMessage()

### Community 109 - "Entity (Community 109)"
Cohesion: 0.33
Nodes (6): AiImageNodeTests.cs, Execute_PassesStepOptionsToImagePromptRequest(), Execute_ReturnsNullOutput_OnEmptyArray(), var(), Execute_ReturnsSuccess_WhenRequired_AndImageProduced(), Execute_Throws_WhenProviderNameIsUnknown()

### Community 110 - "Entity (Community 110)"
Cohesion: 0.33
Nodes (6): XApiClient.cs, FinalizeMediaAsync(), SignRequest(), if(), AppendMediaSegmentsAsync(), ThrowIfNotSuccess()

### Community 130 - "Entity (Community 130)"
Cohesion: 0.60
Nodes (6): AzureFoundryOptionsValidator.cs, AzureFoundryOptionsValidator.cs, XPoster.Models, Validate(), if(), nameof()

### Community 128 - "Entity (Community 128)"
Cohesion: 0.60
Nodes (6): AiClientsResiliencePipelineTests.cs, AiClientsResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_AiClient_RetriesOn429_AndEventuallySucceeds(), Polly_AiClient_AttemptTimeout_CancelsSlowRequest(), StringContent()

### Community 129 - "Entity (Community 129)"
Cohesion: 0.33
Nodes (6): LinkedInResiliencePipelineTests.cs, XPoster.Tests.Integration, Polly_LinkedIn_RetriesOn429_AndEventuallySucceeds(), for(), Polly_LinkedIn_CircuitBreaker_OpensAfterConsecutiveFailures(), Polly_LinkedIn_AttemptTimeout_CancelsSlowRequest()

### Community 113 - "Entity (Community 113)"
Cohesion: 0.60
Nodes (6): FacebookCredentialsValidator.cs, FacebookCredentialsValidator.cs, Validate(), FacebookCredentialsValidator, if(), XPoster.Credentials

### Community 112 - "Entity (Community 112)"
Cohesion: 0.60
Nodes (6): TagReplacementServiceTests.cs, TagReplacementServiceTests.cs, Apply_Does_Not_Replace_Words_Already_Prefixed_With_Hashtag(), Apply_Replaces_Only_First_Occurrence_For_Each_Word(), Apply_Returns_Input_Unchanged_When_Text_Is_Empty_Or_Whitespace(), XPoster.Tests.Services

### Community 135 - "Entity (Community 135)"
Cohesion: 0.60
Nodes (6): DeepSeekOptionsTests.cs, DeepSeekOptionsTests.cs, DeepSeekOptions_Defaults_AreCorrect(), XPoster.Tests.Models, DeepSeekOptionsTests, DeepSeekOptions_DoesNotExpose_ApiVersionProperty()

### Community 134 - "Entity (Community 134)"
Cohesion: 0.60
Nodes (6): IWorkflowContext.cs, IWorkflowContext.cs, SetData(), XPoster.Workflows.Models, IWorkflowContext, HasData()

### Community 118 - "Entity (Community 118)"
Cohesion: 0.60
Nodes (6): InstagramCredentialsValidator.cs, InstagramCredentialsValidator.cs, Validate(), InstagramCredentialsValidator, XPoster.Credentials, if()

### Community 117 - "Entity (Community 117)"
Cohesion: 0.60
Nodes (6): DryRunSender.cs, DryRunSender.cs, if(), SendAsync(), DryRunSender(), XPoster.SenderPlugins

### Community 124 - "Entity (Community 124)"
Cohesion: 0.60
Nodes (6): OpenAiOptionsValidator.cs, OpenAiOptionsValidator.cs, Validate(), if(), nameof(), XPoster.Models

### Community 122 - "Entity (Community 122)"
Cohesion: 0.33
Nodes (6): AiServiceHelperImageTests.cs, HttpClient(), JsonResponse(), MakeDownloadClient(), MakeNoOpClient(), var()

### Community 123 - "Entity (Community 123)"
Cohesion: 0.33
Nodes (6): NodeParameterExtractor.cs, catch(), GetProvider(), IsJsonLike(), XPoster.Workflows.Utilities, return()

### Community 167 - "Entity (Community 167)"
Cohesion: 0.40
Nodes (5): InstagramResiliencePipelineTests.cs, Polly_Instagram_RetriesOn429_AndEventuallySucceeds(), catch(), Polly_Instagram_CircuitBreaker_OpensAfterConsecutiveFailures(), XPoster.Tests.Integration

### Community 162 - "Entity (Community 162)"
Cohesion: 0.70
Nodes (5): IOrchestratorFactory.cs, IOrchestratorFactory.cs, XPoster.Contracts, Resolve(), IOrchestratorFactory

### Community 165 - "Entity (Community 165)"
Cohesion: 0.70
Nodes (5): ISender.cs, ISender.cs, ISender, XPoster.Contracts, SendAsync()

### Community 164 - "Entity (Community 164)"
Cohesion: 0.70
Nodes (5): IFeedService.cs, IFeedService.cs, GetFeedsAsync(), XPoster.Contracts, IFeedService

### Community 163 - "Entity (Community 163)"
Cohesion: 0.70
Nodes (5): ITextToImageProvider.cs, ITextToImageProvider.cs, ITextToImageProvider, XPoster.Contracts, GenerateImageAsync()

### Community 166 - "Entity (Community 166)"
Cohesion: 0.70
Nodes (5): ICredentialsStartupValidator.cs, ICredentialsStartupValidator.cs, XPoster.Contracts, ICredentialsStartupValidator, Validate()

### Community 157 - "Entity (Community 157)"
Cohesion: 0.40
Nodes (5): XApiClientTests.cs, if(), OkJson(), HttpResponseMessage(), BuildApiClient()

### Community 159 - "Entity (Community 159)"
Cohesion: 0.70
Nodes (5): LocalOverrideTimeProvider.cs, LocalOverrideTimeProvider.cs, GetCurrentTime(), XPoster.Providers, LocalOverrideTimeProvider()

### Community 161 - "Entity (Community 161)"
Cohesion: 0.70
Nodes (5): LinkedInCredentialsValidator.cs, LinkedInCredentialsValidator.cs, if(), XPoster.Credentials, Validate()

### Community 160 - "Entity (Community 160)"
Cohesion: 0.70
Nodes (5): TimeProvider.cs, TimeProvider.cs, TimeProvider, GetCurrentTime(), XPoster.Providers

### Community 158 - "Entity (Community 158)"
Cohesion: 0.70
Nodes (5): ConfigurationTagReplacementProvider.cs, ConfigurationTagReplacementProvider.cs, XPoster.Providers, GetReplacements(), ConfigurationTagReplacementProvider()

### Community 143 - "Entity (Community 143)"
Cohesion: 0.70
Nodes (5): WorkflowDefinitionOptions.cs, WorkflowDefinitionOptions.cs, XPoster.Workflows.Configuration, WorkflowDefinition(), ToDefinition()

### Community 140 - "Entity (Community 140)"
Cohesion: 0.70
Nodes (5): IOrchestrator.cs, IOrchestrator.cs, PostAsync(), XPoster.Contracts, IOrchestrator

### Community 141 - "Entity (Community 141)"
Cohesion: 0.70
Nodes (5): ICryptoService.cs, ICryptoService.cs, ICryptoService, GetCryptoValue(), XPoster.Contracts

### Community 142 - "Entity (Community 142)"
Cohesion: 0.70
Nodes (5): IWorkflowNode.cs, IWorkflowNode.cs, XPoster.Workflows.Abstractions, ExecuteAsync(), IWorkflowNode

### Community 136 - "Entity (Community 136)"
Cohesion: 0.40
Nodes (5): PerplexityService.cs, var(), if(), GenerateTextAsync(), XPoster.Services

### Community 148 - "Entity (Community 148)"
Cohesion: 0.70
Nodes (5): MaskUrlTelemetryProcessor.cs, MaskUrlTelemetryProcessor.cs, if(), MaskUrlTelemetryProcessor(), Process()

### Community 150 - "Entity (Community 150)"
Cohesion: 0.70
Nodes (5): AiProviderValidationHelper.cs, AiProviderValidationHelper.cs, ValidateConnectivity(), if(), XPoster.Models

### Community 149 - "Entity (Community 149)"
Cohesion: 0.70
Nodes (5): PromptRequest.cs, PromptRequest.cs, XPoster.Models, PromptRequest, ImagePromptRequest

### Community 152 - "Entity (Community 152)"
Cohesion: 0.40
Nodes (5): OpenAiService.cs, GetChatCompletionsEndpoint(), OpenAiService(), GetImageGenerationEndpoint(), if()

### Community 151 - "Entity (Community 151)"
Cohesion: 0.70
Nodes (5): ITimeProvider.cs, ITimeProvider.cs, XPoster.Contracts, GetCurrentTime(), ITimeProvider

### Community 137 - "Entity (Community 137)"
Cohesion: 0.40
Nodes (5): FeedService.cs, Exception(), XPoster.Services, GetFeedsAsync(), catch()

### Community 139 - "Entity (Community 139)"
Cohesion: 0.70
Nodes (5): ITextToTextProvider.cs, ITextToTextProvider.cs, XPoster.Contracts, GenerateTextAsync(), ITextToTextProvider

### Community 138 - "Entity (Community 138)"
Cohesion: 0.70
Nodes (5): IWorkflowEngine.cs, IWorkflowEngine.cs, XPoster.Workflows.Engine, IWorkflowEngine, ExecuteAsync()

### Community 168 - "Entity (Community 168)"
Cohesion: 0.40
Nodes (5): ResilienceTestHelpers.cs, BuildFactory(), SendAsync(), _responder(), params()

### Community 169 - "Entity (Community 169)"
Cohesion: 0.70
Nodes (5): ImageTestData.cs, ImageTestData.cs, CreateValidJpeg(), XPoster.Tests.Helpers, CreateValidPng()

### Community 170 - "Entity (Community 170)"
Cohesion: 0.40
Nodes (5): DeepSeekService.cs, XPoster.Services, var(), if(), GenerateTextAsync()

### Community 156 - "Entity (Community 156)"
Cohesion: 0.70
Nodes (5): ISlotProfileProvider.cs, ISlotProfileProvider.cs, ISlotProfileProvider, XPoster.Contracts, GetProfiles()

### Community 153 - "Entity (Community 153)"
Cohesion: 0.70
Nodes (5): IAiProviderOptions.cs, IAiProviderOptions.cs, IAiProviderOptions, IAiProviderSection, XPoster.Contracts

### Community 155 - "Entity (Community 155)"
Cohesion: 0.70
Nodes (5): ITagReplacementProvider.cs, ITagReplacementProvider.cs, GetReplacements(), ITagReplacementProvider, XPoster.Contracts

### Community 154 - "Entity (Community 154)"
Cohesion: 0.70
Nodes (5): ITagReplacementService.cs, ITagReplacementService.cs, Apply(), ITagReplacementService, XPoster.Contracts

### Community 144 - "Entity (Community 144)"
Cohesion: 0.70
Nodes (5): ConfigurationStepOptionsResolver.cs, ConfigurationStepOptionsResolver.cs, XPoster.Workflows.Services, ConfigurationStepOptionsResolver(), Resolve()

### Community 147 - "Entity (Community 147)"
Cohesion: 0.70
Nodes (5): WorkflowOrchestrator.cs, WorkflowOrchestrator.cs, XPoster.Orchestrators, WorkflowOrchestrator(), if()

### Community 146 - "Entity (Community 146)"
Cohesion: 0.70
Nodes (5): IStepOptionsResolver.cs, IStepOptionsResolver.cs, IStepOptionsResolver, Resolve(), XPoster.Workflows.Services

### Community 145 - "Entity (Community 145)"
Cohesion: 0.70
Nodes (5): OpenAiOptionsValidatorTests.cs, OpenAiOptionsValidatorTests.cs, ValidOptions(), OpenAiOptionsValidatorTests, XPoster.Tests.Models

### Community 189 - "Entity (Community 189)"
Cohesion: 0.50
Nodes (4): ConfigurationSlotProfileProvider.cs, XPoster.Providers, ConfigurationSlotProfileProvider(), GetProfiles()

### Community 197 - "Entity (Community 197)"
Cohesion: 0.50
Nodes (4): WorkflowExecutionEngineTests.cs, new(), StubNode(), var()

### Community 190 - "Entity (Community 190)"
Cohesion: 0.50
Nodes (4): DeepSeekService.cs, while(), DeepSeekService(), GetChatCompletionsEndpoint()

### Community 196 - "Entity (Community 196)"
Cohesion: 0.50
Nodes (4): FalAiOptionsValidator.cs, Validate(), XPoster.Models, foreach()

### Community 191 - "Entity (Community 191)"
Cohesion: 0.83
Nodes (4): NoOrchestrator.cs, NoOrchestrator.cs, NoOrchestrator(), XPoster.Orchestrators

### Community 192 - "Entity (Community 192)"
Cohesion: 0.50
Nodes (4): CryptoService.cs, GetCryptoValue(), XPoster.Services, catch()

### Community 193 - "Entity (Community 193)"
Cohesion: 0.83
Nodes (4): DryRunMaxLengthSender.cs, DryRunMaxLengthSender.cs, DryRunMaxLengthSender(), XPoster.SenderPlugins

### Community 194 - "Entity (Community 194)"
Cohesion: 0.83
Nodes (4): AiProviderServiceCollectionExtensions.cs, AiProviderServiceCollectionExtensions.cs, AddXPosterAiProviders(), XPoster.Extensions

### Community 195 - "Entity (Community 195)"
Cohesion: 0.83
Nodes (4): AiProviderOptionsCompositionExtensions.cs, AiProviderOptionsCompositionExtensions.cs, AddAiProviderOptions(), XPoster.Extensions

### Community 181 - "Entity (Community 181)"
Cohesion: 0.83
Nodes (4): SenderPluginsServiceCollectionExtensions.cs, SenderPluginsServiceCollectionExtensions.cs, AddXPosterSenderPlugins(), XPoster.Extensions

### Community 187 - "Entity (Community 187)"
Cohesion: 0.50
Nodes (4): HttpClientExtensions.cs, AddHttpClients(), XPoster.Extensions, AddResilientHttpClient()

### Community 188 - "Entity (Community 188)"
Cohesion: 0.50
Nodes (4): InstagramResiliencePipelineTests.cs, StringContent(), Polly_Instagram_AttemptTimeout_CancelsSlowRequest(), for()

### Community 186 - "Entity (Community 186)"
Cohesion: 0.50
Nodes (4): CredentialsStartupValidator.cs, ValidateOptions(), foreach(), resolve()

### Community 185 - "Entity (Community 185)"
Cohesion: 0.83
Nodes (4): BlobUploadResult.cs, BlobUploadResult.cs, BlobUploadResult(), XPoster.Models

### Community 182 - "Entity (Community 182)"
Cohesion: 0.83
Nodes (4): CredentialsExtensions.cs, CredentialsExtensions.cs, AddCredentials(), XPoster.Credentials

### Community 183 - "Entity (Community 183)"
Cohesion: 0.50
Nodes (4): LinkedInResiliencePipelineTests.cs, StringContent(), catch(), Polly_LinkedIn_OnRetry_LogEntryIsEmitted()

### Community 184 - "Entity (Community 184)"
Cohesion: 0.83
Nodes (4): RSSFeed.cs, RSSFeed.cs, RSSFeed, XPoster.Models

### Community 180 - "Entity (Community 180)"
Cohesion: 0.50
Nodes (4): AiServiceHelper.cs, return(), if(), catch()

### Community 174 - "Entity (Community 174)"
Cohesion: 0.83
Nodes (4): DryRunShortLengthSender.cs, DryRunShortLengthSender.cs, XPoster.SenderPlugins, DryRunShortLengthSender()

### Community 176 - "Entity (Community 176)"
Cohesion: 0.83
Nodes (4): WorkflowNodeDefinition.cs, WorkflowNodeDefinition.cs, XPoster.Workflows.Engine, WorkflowNodeDefinition()

### Community 178 - "Entity (Community 178)"
Cohesion: 0.83
Nodes (4): MediaAttachment.cs, MediaAttachment.cs, XPoster.Workflows.Models, MediaAttachment()

### Community 177 - "Entity (Community 177)"
Cohesion: 0.83
Nodes (4): PendingContainer.cs, PendingContainer.cs, XPoster.Models, PendingContainer()

### Community 175 - "Entity (Community 175)"
Cohesion: 0.83
Nodes (4): WorkflowExecutionResult.cs, WorkflowExecutionResult.cs, XPoster.Workflows.Engine, WorkflowExecutionResult()

### Community 179 - "Entity (Community 179)"
Cohesion: 0.50
Nodes (4): WorkflowOrchestratorTests.cs, WorkflowExecutionResult(), var(), new()

### Community 205 - "Entity (Community 205)"
Cohesion: 0.50
Nodes (4): PerplexityService.cs, while(), GetChatCompletionsEndpoint(), PerplexityService()

### Community 198 - "Entity (Community 198)"
Cohesion: 0.83
Nodes (4): ITerminalNode.cs, ITerminalNode.cs, ITerminalNode, XPoster.Workflows.Abstractions

### Community 204 - "Entity (Community 204)"
Cohesion: 0.50
Nodes (4): FanOutSendNodeTests.cs, var(), if(), SetupSender()

### Community 200 - "Entity (Community 200)"
Cohesion: 0.83
Nodes (4): WorkflowDefinition.cs, WorkflowDefinition.cs, XPoster.Workflows.Engine, WorkflowDefinition()

### Community 199 - "Entity (Community 199)"
Cohesion: 0.50
Nodes (4): WorkflowDefinitionValidatorTests.cs, ExecuteAsync(), new(), Node()

### Community 201 - "Entity (Community 201)"
Cohesion: 0.83
Nodes (4): WorkflowNodeInput.cs, WorkflowNodeInput.cs, XPoster.Workflows.Abstractions, WorkflowNodeInput()

### Community 202 - "Entity (Community 202)"
Cohesion: 0.83
Nodes (4): WorkflowNodeResult.cs, WorkflowNodeResult.cs, WorkflowNodeResult(), XPoster.Workflows.Abstractions

### Community 203 - "Entity (Community 203)"
Cohesion: 0.83
Nodes (4): AiProviderExtensions.cs, AiProviderExtensions.cs, XPoster.Contracts, GetLabel()

### Community 173 - "Entity (Community 173)"
Cohesion: 0.50
Nodes (4): BaseOrchestrator.cs, XPoster.Orchestrators, BaseOrchestrator(), PostAsync()

### Community 172 - "Entity (Community 172)"
Cohesion: 0.83
Nodes (4): Post.cs, Post.cs, Post, XPoster.Models

### Community 171 - "Entity (Community 171)"
Cohesion: 0.83
Nodes (4): ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile.cs, ScheduledOrchestrationProfile(), XPoster.Models

### Community 219 - "Entity (Community 219)"
Cohesion: 1.00
Nodes (3): XPoster.Workflows.Models, MediaType.cs, MediaType.cs

### Community 206 - "Entity (Community 206)"
Cohesion: 1.00
Nodes (3): XPoster.Models, PerplexityOptions.cs, PerplexityOptions.cs

### Community 218 - "Entity (Community 218)"
Cohesion: 1.00
Nodes (3): PromptStepOptions.cs, PromptStepOptions.cs, XPoster.Workflows.Models

### Community 207 - "Entity (Community 207)"
Cohesion: 1.00
Nodes (3): OpenAiOptions.cs, XPoster.Models, OpenAiOptions.cs

### Community 217 - "Entity (Community 217)"
Cohesion: 1.00
Nodes (3): AzureFoundryOptions.cs, XPoster.Models, AzureFoundryOptions.cs

### Community 209 - "Entity (Community 209)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, XCredentials.cs, XCredentials.cs

### Community 211 - "Entity (Community 211)"
Cohesion: 0.67
Nodes (3): HttpClientExtensions.cs, IsTransientHttpFailure(), if()

### Community 210 - "Entity (Community 210)"
Cohesion: 1.00
Nodes (3): FacebookCredentials.cs, XPoster.Credentials, FacebookCredentials.cs

### Community 208 - "Entity (Community 208)"
Cohesion: 0.67
Nodes (3): XCredentialsValidator.cs, XPoster.Credentials, Validate()

### Community 215 - "Entity (Community 215)"
Cohesion: 1.00
Nodes (3): SenderPlatform.cs, XPoster.Contracts, SenderPlatform.cs

### Community 216 - "Entity (Community 216)"
Cohesion: 1.00
Nodes (3): XPoster.Credentials, LinkedInCredentials.cs, LinkedInCredentials.cs

### Community 212 - "Entity (Community 212)"
Cohesion: 1.00
Nodes (3): AiModelClass.cs, AiModelClass.cs, XPoster.Contracts

### Community 214 - "Entity (Community 214)"
Cohesion: 0.67
Nodes (3): BaseOrchestrator.cs, DispatchAsync(), if()

### Community 213 - "Entity (Community 213)"
Cohesion: 0.67
Nodes (3): ConfigurationSlotProfileProvider.cs, foreach(), if()

### Community 220 - "Entity (Community 220)"
Cohesion: 1.00
Nodes (3): InstagramCredentials.cs, XPoster.Credentials, InstagramCredentials.cs

### Community 233 - "Entity (Community 233)"
Cohesion: 1.00
Nodes (3): WorkflowContextKeys.cs, XPoster.Workflows.Models, WorkflowContextKeys.cs

### Community 232 - "Entity (Community 232)"
Cohesion: 0.67
Nodes (3): NodeParameterExtractor.cs, InvalidOperationException(), if()

### Community 234 - "Entity (Community 234)"
Cohesion: 1.00
Nodes (3): ContainerStatus.cs, ContainerStatus.cs, XPoster.Contracts

### Community 229 - "Entity (Community 229)"
Cohesion: 1.00
Nodes (3): XPoster.Models, TagReplacementOptions.cs, TagReplacementOptions.cs

### Community 230 - "Entity (Community 230)"
Cohesion: 1.00
Nodes (3): AiProvider.cs, XPoster.Contracts, AiProvider.cs

### Community 231 - "Entity (Community 231)"
Cohesion: 0.67
Nodes (3): FbSenderResilienceTests.cs, BuildFactory(), BuildCreds()

### Community 221 - "Entity (Community 221)"
Cohesion: 1.00
Nodes (3): BlobStorageOptions.cs, BlobStorageOptions.cs, XPoster.Models

### Community 222 - "Entity (Community 222)"
Cohesion: 1.00
Nodes (3): DeepSeekOptions.cs, XPoster.Models, DeepSeekOptions.cs

### Community 223 - "Entity (Community 223)"
Cohesion: 1.00
Nodes (3): FalAiOptions.cs, FalAiOptions.cs, XPoster.Models

### Community 224 - "Entity (Community 224)"
Cohesion: 1.00
Nodes (3): SlotScheduleOptions.cs, XPoster.Models, SlotScheduleOptions.cs

### Community 225 - "Entity (Community 225)"
Cohesion: 0.67
Nodes (3): FalAiOptionsValidator.cs, if(), nameof()

### Community 227 - "Entity (Community 227)"
Cohesion: 0.67
Nodes (3): InSender.cs, if(), InSender()

### Community 228 - "Entity (Community 228)"
Cohesion: 0.67
Nodes (3): FeedService.cs, FeedService(), if()

### Community 226 - "Entity (Community 226)"
Cohesion: 0.67
Nodes (3): CryptoService.cs, CryptoService(), if()

### Community 236 - "Entity (Community 236)"
Cohesion: 1.00
Nodes (2): XApiException.cs, if()

### Community 235 - "Entity (Community 235)"
Cohesion: 1.00
Nodes (2): XCredentialsValidator.cs, if()

## Suggested Questions
_Not enough signal to generate questions. The graph has no ambiguous edges, no bridge nodes, and all communities are well-connected._

