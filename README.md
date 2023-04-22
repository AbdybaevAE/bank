## System architecture requirements:
- Event Sourcing 
- CQRS
- PostgreSQL as event store
- MongoDb as read model

### Functionality:
- Manage accounts(create, read, update, delete, block)
- Credit account
    - Via ATM
    - Via bank branch
    - External System(VISA)
- Transfers by account number

### Account properties:
- External Id
- Number(IBAN format)
- Balance(default to 0)
- Currency
- Date created
- Is blocked flag

### Transfer properties:
- Account from number
- Account to number
- Amount

### Limits notion:
- No more 2 000 000 KZT per individual transfer
- No more than 5 000 000 KZT transfers per day limit
