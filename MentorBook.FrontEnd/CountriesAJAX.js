async function getAllCountries(){
    let url = 'https://localhost:5001/api/Location/GetAllCountries'
    let res = await fetch(url)

    let countries = await res.json()

    let dropdownTarget = document.querySelector('.countrySelector')
    

    for(let i = 0; i < countries.length; i++)
    {
        let newCountryOption = document.createElement('option')
        newCountryOption.innerText = countries[i]['name']
        newCountryOption.id = countries[i]['id']

        dropdownTarget.appendChild(newCountryOption)

        newCountryOption.addEventListener('click', ()=>{
            let targetCountryID = newCountryOption['id']
            getCitiesByCountry(targetCountryID)
        })
    }

}

async function getCitiesByCountry(countryID)
{
    let url = `https://localhost:5001/api/Location/GetCitiesByCountryId?countryId=${countryID}`
    let res = await fetch(url)

    let country_cities = await res.json()

    let targetDropdown = document.querySelector('.citiesSelector')
    targetDropdown.replaceChildren()

    if(country_cities.length <= 0)
    {
        let newCityOption = document.createElement('option')
        newCityOption.innerText = 'No cities available'

        targetDropdown.appendChild(newCityOption)
    }
    else
    {
        for(let i = 0; i < country_cities.length; i++)
        {
            let newCityOption = document.createElement('option')
            newCityOption.innerText = country_cities[i]['name']
            newCityOption.id = country_cities[i]['id']
    
            targetDropdown.appendChild(newCityOption)
        }
    }
}


getAllCountries()
getCitiesByCountry(9)