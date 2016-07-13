# Address Lookup Prototype

## Summary

A self hosted (via TopShelf) NancyFx API to support querying Elasticsearch via the routes:
* `addresses/suggest`
* `addresses/query`

## Configuration

The Elasticsearch Host and Index can be specified in the `App.config`.

## Running

Simply run the `AddressLookup.Api` console project, it will bind to `http://localhost:1234`

## Testing

The `AddressLookup.Api.Tests` project contains the tests. The tests use BDDfy, but any test runner that supports NUnit 2.6.4 can run the tests.
