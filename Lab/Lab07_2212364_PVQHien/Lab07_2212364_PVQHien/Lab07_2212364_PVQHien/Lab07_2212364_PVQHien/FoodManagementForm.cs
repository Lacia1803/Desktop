using Lab07_2212364_PVQHien.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Lab07_2212364_PVQHien
{
	public partial class FoodManagementForm : Form
	{
		private RestaurantContext _dbContext = new RestaurantContext();

		public FoodManagementForm()
		{
			InitializeComponent();
		}

		private void FoodManagementForm_Load(object sender, EventArgs e)
		{
			LoadCategories();
			LoadFoods();
		}

		private void LoadCategories()
		{
			tvCategories.Nodes.Clear();
			var categories = _dbContext.Categories.OrderBy(x => x.Type).ThenBy(x => x.Name).ToList();

			TreeNode foodNode = new TreeNode("Đồ ăn");
			TreeNode drinkNode = new TreeNode("Đồ uống");

			foreach (var category in categories)
			{
				var node = new TreeNode(category.Name);
				node.Tag = category;
				
				if (category.Type == CategoryType.Food)
					foodNode.Nodes.Add(node);
				else
					drinkNode.Nodes.Add(node);
			}

			tvCategories.Nodes.Add(foodNode);
			tvCategories.Nodes.Add(drinkNode);
			tvCategories.ExpandAll();
		}

		private void LoadFoods(int? categoryId = null, string searchName = null)
		{
			lvwFoods.Items.Clear();
			var query = _dbContext.Foods.Include(x => x.Category).AsQueryable();

			if (categoryId.HasValue && categoryId.Value > 0)
			{
				query = query.Where(x => x.FoodCategoryId == categoryId.Value);
			}

			if (!string.IsNullOrWhiteSpace(searchName))
			{
				query = query.Where(x => x.Name.Contains(searchName));
			}

			var foods = query.OrderBy(x => x.Name).ToList();

			foreach (var food in foods)
			{
				var item = new ListViewItem(food.Id.ToString());
				item.SubItems.Add(food.Name);
				item.SubItems.Add(food.Unit);
				item.SubItems.Add(food.Price.ToString("N0"));
				item.SubItems.Add(food.Category.Name);
				item.SubItems.Add(food.Notes);
				item.Tag = food;
				lvwFoods.Items.Add(item);
			}
		}

		private void tvCategories_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (e.Node.Tag is Category category)
			{
				LoadFoods(category.Id);
			}
			else
			{
				LoadFoods();
			}
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			var selectedCategory = tvCategories.SelectedNode?.Tag as Category;
			LoadFoods(selectedCategory?.Id, txtSearch.Text.Trim());
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			var form = new UpdateFoodForm(0);
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadFoods();
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (lvwFoods.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn món ăn cần cập nhật", "Thông báo");
				return;
			}

			var food = lvwFoods.SelectedItems[0].Tag as Food;
			if (food != null)
			{
				var form = new UpdateFoodForm(food.Id);
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadFoods();
				}
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (lvwFoods.SelectedItems.Count == 0)
			{
				MessageBox.Show("Vui lòng chọn món ăn cần xóa", "Thông báo");
				return;
			}

			var food = lvwFoods.SelectedItems[0].Tag as Food;
			if (food != null)
			{
				if (MessageBox.Show($"Bạn có chắc muốn xóa món '{food.Name}'?",
					"Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					var foodInDb = _dbContext.Foods.Find(food.Id);
					if (foodInDb != null)
					{
						_dbContext.Foods.Remove(foodInDb);
						_dbContext.SaveChanges();
						LoadFoods();
						MessageBox.Show("Đã xóa món ăn!", "Thông báo");
					}
				}
			}
		}

		private void btnAddCategory_Click(object sender, EventArgs e)
		{
			var form = new UpdateCategoryForm(0);
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadCategories();
			}
		}
	}
}
