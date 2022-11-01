let loadMoreBtn=document.getElementById("load-more")
let productList = document.getElementById("prduct-list")
let skip=4

loadMoreBtn.addEventListener("click",function(){
    fetch('product/partial?skip='+skip)
        .then((response) => response.text())
        .then((data) => {
            productList.innerHTML += data;
            skip += 4;
            let productCount = document.getElementById("prduct-count").value;           
            if (skip >= productCount)
                loadMoreBtn.remove();
        });
})