# Address Lookup Prototype

## Summary

An self hosted (via TopShelf) NancyFx API to support querying Elasticsearch via the routes:
* `addresses/suggest`
* `addresses/query`

## Configuration

The Elasticsearch Host and Index can be specified in the `App.config`

## Testing

The `AddressLookup.Api.Tests` project contains the tests. The tests use BDDfy, but any test runner that supports NUnit 2.6.4 can run the tests.
