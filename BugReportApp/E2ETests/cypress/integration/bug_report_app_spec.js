describe('Bug Report App', () => {

    it('successfully loads', () => {
        cy.visit('/')
    })

    it('creates a bug report', () => {
        cy.get('#create-link').click()
        cy.get('#title-input').type('test title')
        cy.get('#description-input').type('test description containing more detailed information')
        cy.get('#submit-button').click()
    }) 

    it('clicks on delete but cancels', () => {
        cy.contains('test title').parent('tr').within(() => {
            cy.get('td').eq(1).contains('test description containing more detailed information')
            cy.get('td').eq(2).contains('Open')
            cy.get('td').eq(3).contains('Delete').click()
        })
        cy.get('#cancel-link').click();
    })

    it('confirms and deletes a bug report', () => {
        cy.contains('test title').parent('tr').within(() => {
            cy.get('td').eq(1).contains('test description containing more detailed information')
            cy.get('td').eq(2).contains('Open')
            cy.get('td').eq(3).contains('Delete').click()
        })
        cy.get('#submit-button').click()
    })
})
