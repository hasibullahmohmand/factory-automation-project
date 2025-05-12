import requests
from bs4 import BeautifulSoup
import csv
import random
import os

def get_last_product_id(csv_file):
    """Get the last product_id from the existing CSV file (if any)."""
    if not os.path.exists(csv_file):
        return 0

    with open(csv_file, mode='r', encoding='utf-8') as f:
        reader = csv.DictReader(f)
        rows = list(reader)
        if not rows:
            return 0
        return max(int(row['product_id']) for row in rows)

def scrape_ulker_category(url, category_id, output_file):
    BASE_URL = "https://www.ulker.com.tr"

    headers = {
        "User-Agent": "Mozilla/5.0"
    }

    # Define categories and ingredients
    categories = {
        1: "chocolates",
        2: "cakes",
        3: "gums",
        4: "biscuits",
        5: "wafers"
    }

    category = categories.get(category_id, "unknown")
    ingredients_dict = {
        "chocolates": ["cocoa", "milk solids", "sugar", "cocoa butter"],
        "cakes": ["flour", "sugar", "eggs", "butter"],
        "gums": ["gum base", "sweeteners", "flavorings", "glucose syrup"],
        "biscuits": ["wheat flour", "vegetable oil", "salt", "sugar"],
        "wafers": ["wheat flour", "cocoa", "milk powder", "palm oil"]
    }

    # Send HTTP request
    response = requests.get(url, headers=headers)
    soup = BeautifulSoup(response.content, "html.parser")

    # Determine the starting ID
    last_id = get_last_product_id(output_file)
    products = []

    for idx, item in enumerate(soup.select("div.product-box"), start=1):
        title_tag = item.find_next("span", class_="product-title")
        img_tag = item.select_one("img")

        if not title_tag or not img_tag:
            continue

        name = title_tag.text.strip()
        img_src = img_tag["src"]
        full_img_url = BASE_URL + img_src if img_src.startswith("/") else img_src

        ingredients = ", ".join(random.sample(ingredients_dict[category], 3))
        description = f"A delicious {category[:-1]} made with {ingredients}."

        product = {
            "product_id": last_id + idx,
            "product_name": name,
            "imageurl": full_img_url,
            "description": description,
            "stock": 10000,
            "price": random.randint(500, 2000),
            "category_id": category_id
        }

        products.append(product)

    # Write to CSV
    file_exists = os.path.exists(output_file)
    with open(output_file, mode='a', newline='', encoding='utf-8') as f:
        writer = csv.DictWriter(f, fieldnames=products[0].keys())
        if not file_exists or os.path.getsize(output_file) == 0:
            writer.writeheader()
        writer.writerows(products)

    print(f"✅ Scraped {len(products)} products from {url} and saved to {output_file}")


# Example usage
scrape_ulker_category(
    url="https://www.ulker.com.tr/en/brands/ulker-bebe-biscuits",
    category_id=4,
    output_file="ulker_chocolates.csv"
)
