﻿@NoBrowser
Feature: MI

A short summary of the feature

@ratingTests @MI
Scenario: MI - Test Rating Algorithm

	Given quote for LineId=7 state 'MI' and '<Algorithm or Coverage>' is set to Quoted
	When expected values are gathered
	Then expected values should match the system output

	Examples:
	| Algorithm or Coverage |
	| Trailer Interchange   |
	| In-Tow                |
	| Rental Reimbursement  |
	| Cargo Coverage        |
	| VA00058               |
	| VA00059               |
	| VA00060               |
	| VA00061               |
	| VA00062               |
	| VA00063               |
	| VA00064               |
	| VA00065               |
	| VA00066               |
	| VA00067               |
	| VA00068               |
	| VA00069               |
	| VA00041               |
	| VA00042               |
	| VA00043               |
	| VA00044               |
	| VA00070               |
	| VA00071               |
	| VA00072               |
	| VA00048               |
	| VA00049               |