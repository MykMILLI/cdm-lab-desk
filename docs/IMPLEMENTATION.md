# Implementation contract

## Product and packaging
One user-facing product, CDM Labsync; one Windows installer; one staff shortcut. Target Windows 11 and validate the actual Windows 10 editions/builds in use. Package internal helper/server components automatically, not as separate manual installations. Use a supported runtime for production; reassess scaffold net8.0 before shipping. No synchronization-engine fork unless evidence requires it. Evaluate custom Syncthing GUI assets plus a restricted workflow backend; never expose Syncthing administrator credentials/API access to ordinary office users. Do not claim an HTML-only reskin implements local filesystem operations.

## Existing installation preservation
Detect the active Syncthing instance, configuration home, engine version, service account, device identity, folders, shares, and GUI endpoint. Reuse existing state. Never silently create a replacement identity or configuration. Back up before changes; detect ambiguous or unsupported installs and stop. Treat SyncthingWindowsSetup v2.1.1 as an installer-package version distinct from engine version. Review upstream migration requirements and licenses before bundling. App upgrades preserve accounts, database, office mappings, working roots, and existing case data. Syncthing upgrades are explicit, not an automatic side effect of every dashboard update. Do not download or execute unverified binaries. Test installer upgrade and rollback on Windows before publishing it.

## Topology
Portage is the only receiving lab. Akron Office, Locust Office, Mentor Office, and other configured practices are senders. No Akron Lab destination, lab selector, cross-lab queue, or comparison feature. Preserve existing inboxes such as D:\Lab Cases\Locust Office. Map explicit stable office IDs to configured inbox roots. Never merge office folders. Provide All offices and per-office filtering inside authorized scope. Central service/database at Portage; database must not be synchronized by Syncthing. Installer roles: Office, Portage host, Portage workstation. Host is installed once. Network address, TLS, enrollment, and firewall configuration require explicit setup; do not assume offices can reach the host.

## Authentication
Application accounts separate from Syncthing management login. Roles: office-scoped staff, named lab staff, read-only clinical viewer, administrator. Enforce scope server-side on all endpoints including events, history, metrics, and operations. Use established password hashing/session protection, CSRF defenses, rate limiting and secure enrollment. No default production password or shipped secret. Admin unlock and short-lived single-use reset flow; revoke sessions on reset and audit changes. Provide privileged local administrator recovery without deleting the database. Store local Syncthing API keys outside synced folders in protected storage. Clinical viewer cannot mutate cases or open scans.

## Submission and receipt
Large Send this case to the lab action, choose-folder/drag-drop staging via controlled local helper. Preserve original exports. Stable submission ID plus immutable file manifest with relative paths, lengths and hashes. Replicas observing the same ID must not create new submissions. Independent identical submissions need a warning, not silent discarding. Complete local staging before marking a submission ready. Lab verifies all expected files before receipt; folder presence, quiet periods and single-file events are insufficient. Reconcile after restart and periodically; do not rely only on buffered Syncthing events. Show metadata-only notifications without patient identifiers by default.

## Acceptance and file safety
Atomic central reservation prevents concurrent acceptance. Then journal operation, copy to temporary destination outside all synchronized roots, verify manifest, finalize working destination, persist acceptance and owner, then allow exact transfer-copy cleanup. Filesystem and database are not one atomic transaction: implement durable recovery states. Never overwrite a working case. Failed copy leaves source intact. Cleanup failure retains ownership and shows Cleanup pending. Do not expire/reassign reservations while earlier file operations may still run. If workflow service is unavailable, block new acceptance and destructive cleanup. Keep history after inbox removal. Detect source changes and reject unsafe paths, traversal, root overlap, reparse-point escapes and browser-provided arbitrary paths. Treat concurrent export edits as unsafe. Verify folder modes: deletion propagation requires appropriate Send & Receive configuration; it can remove all synchronized replicas, not just the office. Automatic deletion is OFF by default and requires administrator validation. Completion does not delete/archive working files.

## Clinical overview
Read-only Portage overview by office, date and status: waiting, preparing acceptance, in progress, completed, errors, cleanup pending, oldest waiting. Separate submission-to-receipt, receipt-to-acceptance, acceptance-to-completion intervals. Show freshness/agent health, explicit timezone, time-window definitions and sample counts. No staff-performance scoring or scan access by default. Defer advanced trend charts and automated escalation.

## UI
Browser-based dental workspace: charcoal sidebar, warm off-white background, white cards, restrained deep-red accents. Office view: large send action and own-office history. Portage view: own office inboxes, combined queue, Accept case, working-copy progress, Open working folder, Mark complete. Hide administration from ordinary staff with real authorization, not CSS. Report actual states; never substitute simulated counts for implemented data. Define safe helper/browser authentication and origin restrictions before connecting file operations.

## Test fixtures and documentation
User supplied synthetic MOCK-003 metadata, Upper/Lower PLY, two illustrations, lab-order PDF, notes and README. They are NOT native Romexis exports and NOT clinical scans. Attachments are not automatically available in this repository: do not claim to have committed or tested them. Generate separately labelled synthetic fixtures for automated tests if needed. Never add real patient data. Documentation must include office SOP, lab SOP, clinical overview, admin setup, recovery, upgrade/rollback, backup/retention decisions and implemented-versus-planned status. No compliance certification claims.

## Delivery gates
1. Foundation scaffold and Windows CI.
2. Authenticated persisted case ledger with scoped tests and a real office/lab UI.
3. Local staging, manifests, verified receipt and duplicate-event tests.
4. Atomic acceptance plus durable verified working-copy recovery tests.
5. Single installer and existing-install detection with upgrade tests.
6. Dummy-case end-to-end validation before enabling cleanup.
Tests must cover incomplete transfers, concurrent claims, permission failures, source changes, destination collisions, outages, restart at every destructive boundary, cleanup retries, scope bypass attempts, password reset, stale clinical metrics and preservation of Syncthing identity/configuration. Report commands run, failures, and Windows tests not yet performed. No production-ready claim from generated code alone.
