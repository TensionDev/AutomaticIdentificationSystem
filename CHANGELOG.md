# TensionDev.Maritime.AIS

# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]


## [v0.3.0] - 2022-05-12
[v0.3.0](https://github.com/TensionDev/AutomaticIdentificationSystem/releases/tag/v0.3.0)

### Added
- Added Message 9: Standard search and rescue aircraft position report.
- Added Message 10: Coordinated universal time and date inquiry.
- Added Message 11: Coordinated universal time/date response.

### Fixed
- Fixed MMSI decoding.
- Fixed Message 1 Rate of Turn decoding.
- Fixed Message 2 Rate of Turn decoding.
- Fixed Message 3 Rate of Turn decoding.


## [v0.2.1] - 2022-01-25
[v0.2.1](https://github.com/TensionDev/AutomaticIdentificationSystem/releases/tag/v0.2.1)

### Changed
- Changed all AIS Message to include if it is a Data-link Message or a Data-link Own-vessel report.


## [v0.2.0] - 2021-10-02
[v0.2.0](https://github.com/TensionDev/AutomaticIdentificationSystem/releases/tag/v0.2.0)

### Added
- Added Message 2: Position report (Assigned).
- Added Message 3: Position report (Special).
- Added Message 4: Base station report.
- Added Message 18: Standard Class B equipment position report.
- Added Message 24: Class B 'CS' static data.

### Fixed
- Fixed Message 1 default Latitude value. (0x3412140)
- Fixed Message 1 default Longitude value. (0x6791AC0)


## [v0.1.0-alpha] - 2021-09-13
[v0.1.0-alpha](https://github.com/TensionDev/AutomaticIdentificationSystem/releases/tag/v0.1.0-alpha)

### Added
- Added Message 1: Position report (Scheduled).
- Added Message 5: Static and voyage related data.