async function getPosts(){
    let userID = window.location.href.split('?arg=')[1]
    let url = `https://localhost:5001/api/Posts/GetPostsOfUser?userId=${userID}`
    
    let res = await fetch(url)
    
    let data = await res.json()
    data.forEach((post) => {
        createPost(post)
    })

    
}

async function createPost(postData){

    let postBody = postData.body
    let postCreationDate = postData.createdDate
    let postID = postData.id
    let postShares = postData.sharedFromPostId
    let postTitle = postData.title
    let postUser = postData.userName
    let postUserID = postData.userId 

    let postComments = await getPostDataById(postID)
    generatePostsHTML(postBody, postCreationDate, postID, postShares, postTitle, postUser, postUserID, postComments)
}


function generatePostsHTML(postBody, postCreationDate, postID, postShares, postTitle, postUser, postUserID, postComments)
{
    let postsWrapper = document.querySelector('.postsWrapper')

    let postBlock = document.createElement('div')
    postBlock.className = 'post'
    postBlock.id = postID

    let postOwnerParagraph = document.createElement('p')
    postOwnerParagraph.className = 'postOwner'
    
    let postDate = document.createElement('p')

    postDate.className = 'postDate'

    let breakLine = document.createElement('hr')
    
    let postContent = document.createElement('p')
    postContent.className = 'postContent'
    
    //#region interaction buttons
    let postSharesSpan = document.createElement('span')
    postSharesSpan.className = 'sharesButton button'

    let postSharesIcon = document.createElement('i')
    postSharesIcon.className='fa-solid fa-share-nodes'
    
    let postLikesSpan = document.createElement('span')
    postLikesSpan.className = 'likesButton button'
    
    let postLikesIcon = document.createElement('i')
    postLikesIcon.className='fa-solid fa-thumbs-up'
    
    let postCommentSpan = document.createElement('span')
    postCommentSpan.className = 'CommentButton button'

    let postCommentIcon = document.createElement('i')
    postCommentIcon.className='fa-solid fa-comment'

    let postInteractionButtons = document.createElement('div')
    postInteractionButtons.className='postInteractionButtons' 
    //#endregion
    
    let postCommentSection = document.createElement('div')
    postCommentSection.className = 'commentSection'

    if(postComments.length > 0)
    {
        postComments.forEach((comment) => {
            let commentBody = comment.body
            let commentOwner = comment.userName
            let commentOwnerId = comment.userId
            let commentCreationDate = comment.createdDate

            let commentWrapper = document.createElement('div')
            commentWrapper.className = 'comment'

            let commentBodyElement = document.createElement('p')
            commentBodyElement.className = 'commentBody'
            commentBodyElement.innerText = commentBody

            let commentOwnerElement = document.createElement('span')
            commentOwnerElement.className = 'commentOwner'
            commentOwnerElement.id = commentOwnerId
            commentOwnerElement.innerText = commentOwner

            let commentDateElement = document.createElement('span')
            commentDateElement.className = 'commentPostDate'
            commentOwnerElement.innerText = commentCreationDate

            commentWrapper.appendChild(commentOwnerElement)
            commentWrapper.appendChild(commentDateElement)
            commentWrapper.appendChild(commentBodyElement)
            postCommentSection.appendChild(commentWrapper)

        })
    }
    
    postOwnerParagraph.innerText = postUser
    postDate.innerText = postCreationDate
    
    postContent.innerText = postBody
    
    postSharesSpan.innerText = postShares + '   '
    
    postBlock.appendChild(postOwnerParagraph)
    postBlock.appendChild(postDate)
    postBlock.appendChild(breakLine)
    
    postBlock.appendChild(postContent)
    
    postSharesSpan.appendChild(postSharesIcon)
    postLikesSpan.appendChild(postLikesIcon)
    postCommentSpan.appendChild(postCommentIcon)
    
    postInteractionButtons.appendChild(postSharesSpan)
    postInteractionButtons.appendChild(postLikesSpan)
    postInteractionButtons.appendChild(postCommentSpan)
    
    postBlock.appendChild(postInteractionButtons)
    postBlock.append(postCommentSection)
    
    
    postsWrapper.appendChild(postBlock)
}


async function getPostDataById(id) {
    let res = await fetch(`https://localhost:5001/api/Posts/GetComments?rootPostId=${id}`)
    let comments = await res.json()
    
    return comments
}

getPosts()