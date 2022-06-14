async function fillTableWithData()
{
    let url = 'https://localhost:5001/api/User/GetAll'
    let res = await fetch(url)

    let allUsers = await res.json()

    let targetTable = document.querySelector('.userTable')
    for(let i = 0; i < allUsers.length; i++)
    {
        let userId = allUsers[i]['id']
        let firstName = allUsers[i]['firstName']

        let lastName = allUsers[i]['lastName']
        let email = allUsers[i]['email']


        let newTr = document.createElement('tr')
        newTr.id = userId

        newTr.addEventListener('click', () => {
            getUserDataByID(newTr.id)
        })

        let firstNameTd = document.createElement('td')
        let lastNameTd = document.createElement('td')
        let emailTd = document.createElement('td')

        firstNameTd.innerText = firstName
        lastNameTd.innerText = lastName
        emailTd.innerText = email

        newTr.appendChild(firstNameTd)
        newTr.appendChild(lastNameTd)
        newTr.appendChild(emailTd)

        targetTable.appendChild(newTr)

    }
}

async function getUserDataByID(userID)
{
    let res = await fetch(`https://localhost:5001/api/User/GetUserDetails/${userID}`)

    let userDetails = await res.json()

    let userDetailsContainer = document.querySelector('.userDetails')
    userDetailsContainer.style.display = 'block'
    
    let userFirstName = userDetails['firstName']
    let userLastName = userDetails['lastName']
    let userEmail = userDetails['email']

    let firstNameParagraph = userDetailsContainer.children[0]
    let lastNameParagraph = userDetailsContainer.children[1]
    let emailParagraph = userDetailsContainer.children[2]

    firstNameParagraph.innerText = userFirstName
    lastNameParagraph.innerText = userLastName
    emailParagraph.innerText = userEmail

    let userPostsButton = document.querySelector('.showUserPosts')
    userPostsButton.id = userDetails.id
    
    userPostsButton.addEventListener('click', ()=>{
        showUserPostsById(userPostsButton.id)
    })

    userDetailsContainer.appendChild(userPostsButton)

    

}

async function showUserPostsById(userId){
    
    window.location = 'file:///home/martin/Desktop/git%20clone/MentorBook/MentorBook.FrontEnd/userPosts.html' + `?arg=${userId}`
}
fillTableWithData()