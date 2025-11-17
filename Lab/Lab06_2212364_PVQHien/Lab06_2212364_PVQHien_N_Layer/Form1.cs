using Lab06_2212364_PVQHien.BUS;
using Lab06_2212364_PVQHien.DA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab06_2212364_PVQHien.Win
{
    public partial class frmFood : Form
    {
        // Danh sách toàn cục bảng Category
        List<Category> listCategory = new List<Category>();
        // Danh sách toàn cục bảng Food
        List<Food> listFood = new List<Food>();
        // Đối tượng Food đang chọn hiện hành
        Food foodCurrent = new Food();

        public frmFood()
        {
            InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn thoát chương trình?", "Thoát chương trình?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            //Gán các ô bằng giá trị mặc định
            txtName.Text = "";
            txtPrice.Text = "0";
            txtNotes.Text = "";

            // Thiết lập index = 0 cho ComboBox
            if (cbbCategory.Items.Count > 0)
                cbbCategory.SelectedIndex = 0;
        }

        private void frmFood_Load(object sender, EventArgs e)
        {
            //Đổ dữ liệu vào ComboBox
            LoadCategory();
            // Đổ dữ liệu vào ListView
            LoadFoodDataToListView();
        }

        private void LoadCategory()
        {
            //Gọi đối tượng CategoryBL từ tầng BusinessLogic
            CategoryBL categoryBL = new CategoryBL();
            // Lấy dữ liệu gán cho biến toàn cục listCategory
            listCategory = categoryBL.GetAll();
            // Chuyển vào Combobox với dữ liệu là ID, hiển thị là Name
            cbbCategory.DataSource = listCategory;
            cbbCategory.ValueMember = "ID";
            cbbCategory.DisplayMember = "Name";
        }
        public void LoadFoodDataToListView()
        {
            //Gọi đối tượng FoodBL từ tầng BusinessLogic
            FoodBL foodBL = new FoodBL();
            // Lấy dữ liệu
            listFood = foodBL.GetAll();
            int count = 1; // Biến số thứ tự
            // Xoá dữ liệu trong ListView
            lsvFood.Items.Clear();
            // Duyệt mảng dữ liệu để đưa vào ListView
            foreach (var food in listFood)
            {
                // Số thứ tự
                ListViewItem item = lsvFood.Items.Add(count.ToString());
                // Đưa dữ liệu Name, price vào cột tiếp theo
                item.SubItems.Add(food.Name);
                item.SubItems.Add(food.Price.ToString());
                // Theo dữ liệu của bảng FoodCategory ID, lấy Name để hiển thị
                string categoryName = listCategory
                .Find(x => x.ID == food.FoodCategoryID).Name;
                item.SubItems.Add(categoryName);
                // Đưa dữ liệu Notes vào cột cuối
                item.SubItems.Add(food.Notes);
                count++;
            }
        }

        private void lsvFood_Click(object sender, EventArgs e)
        {
            // Duyệt toàn bộ dữ liệu trong ListView
            for (int i = 0; i < lsvFood.Items.Count; i++)
            {
                // Nếu có dòng được chọn thì lấy dòng đó
                if (lsvFood.Items[i].Selected)
                {// Lấy các tham số và gán dữ liệu vào các ô
                    foodCurrent = listFood[i];
                    txtName.Text = foodCurrent.Name;
                    txtPrice.Text = foodCurrent.Price.ToString();
                    txtNotes.Text = foodCurrent.Notes;
                    // Lấy index của Combobox theo FoodCategoryID
                    cbbCategory.SelectedIndex = listCategory
                    .FindIndex(x => x.ID == foodCurrent.FoodCategoryID);
                }
            }
        }

        /// <summary>
        /// Phương thức thêm dữ liệu cho bảng Food
        /// </summary>
        /// <returns>Trả về số dương nếu thành công, ngược lại trả về số âm</returns>
        public int InsertFood()
        {
            //Khai báo đối tượng Food từ tầng DataAccess
            Food food = new Food();
            food.ID = 0;
            // Kiểm tra nếu các ô nhập khác rỗng
            if (txtName.Text == "" || txtPrice.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                //Nhận giá trị Name và Notes từ người dùng nhập vào
                food.Name = txtName.Text;
                food.Notes = txtNotes.Text;
                // Giá trị price là giá trị số nên cần bắt lỗi khi người dùng nhập sai
                int price = 0;
                try
                {
                    // Cố gắng lấy giá trị
                    price = int.Parse(txtPrice.Text);
                }
                catch
                {
                    // Nếu sai, gán giá = 0
                    price = 0;
                }
                food.Price = price;
                // Giá trị FoodCategoryID được lấy từ ComboBox
                food.FoodCategoryID = int.Parse(cbbCategory.SelectedValue.ToString());
                // Khao báo đối tượng FoodBL từ tầng Business
                FoodBL foodBL = new FoodBL();
                // Chèn dữ liệu vào bảng
                return foodBL.Insert(food);
            }
            return -1;
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            // Gọi phương thức thêm dữ liệu
            int result = InsertFood();
            if (result > 0) // Nếu thêm thành công
            {
                // Thông báo kết quả
                MessageBox.Show("Thêm dữ liệu thành công");
                // Tải lại dữ liệu cho ListView
                LoadFoodDataToListView();
            }
            // Nếu thêm không thành công thì thông báo cho người dùng
            else MessageBox.Show("Thêm dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            // Hỏi người dùng có chắc chắn xoá hay không? Nếu đồng ý thì
            if (MessageBox.Show("Bạn có chắc chắn muốn xoá mẫu tin này?", "Thông báo",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Khai báo đối tượng FoodBL từ BusinessLogic
                    FoodBL foodBL = new FoodBL();
                    if (foodBL.Delete(foodCurrent) > 0)// Nếu xoá thành công
                    {
                        MessageBox.Show("Xoá thực phẩm thành công");
                        // Tải tữ liệu lên ListView
                        LoadFoodDataToListView();
                    }
                    else MessageBox.Show("Xoá không thành công");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Message.Contains("REFERENCE constraint") || ex.Message.Contains("FK_"))
                    {
                        MessageBox.Show("Không thể xoá món ăn này vì đã có trong hóa đơn!\n\n" +
                            "Món ăn này đang được sử dụng trong các hóa đơn, không thể xoá.",
                            "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi cơ sở dữ liệu", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Phương thức cập nhật dữ liệu cho bảng Food
        /// </summary>
        /// <returns>Trả về dương nếu cập nhật thành công, ngược lại là số âm</returns>
        public int UpdateFood()
        {
            //Khai báo đối tượng Food và lấy đối tượng hiện hành
            Food food = foodCurrent;
            // Kiểm tra nếu các ô nhập khác rỗng
            if (txtName.Text == "" || txtPrice.Text == "")
                MessageBox.Show("Chưa nhập dữ liệu cho các ô, vui lòng nhập lại");
            else
            {
                //Nhận giá trị Name và Notes khi người dùng sửa
                food.Name = txtName.Text;
                food.Notes = txtNotes.Text;
                //Giá trị price là giá trị số nên cần bắt lỗi khi người dùng nhập sai
                int price = 0;
                try
                {
                    // Chuyển giá trị từ kiểu văn bản qua kiểu int
                    price = int.Parse(txtPrice.Text);
                }
                catch
                {
                    // Nếu sai, gán giá = 0
                    price = 0;
                }
                food.Price = price;
                // Giá trị FoodCategoryID được lấy từ ComboBox
                food.FoodCategoryID = int.Parse(cbbCategory.SelectedValue.ToString());
                // Khao báo đối tượng FoodBL từ tầng Business
                FoodBL foodBL = new FoodBL();
                // Cập nhật dữ liệu trong bảng
                return foodBL.Update(food);
            }
            return -1;
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            // Gọi phương thức cập nhật dữ liệu
            int result = UpdateFood();
            if (result > 0) // Nếu cập nhật thành công
            {
                // Thông báo kết quả
                MessageBox.Show("Cập nhật dữ liệu thành công");
                // Tải lại dữ liệu cho ListView
                LoadFoodDataToListView();
            }
            // Nếu thêm không thành công thì thông báo cho người dùng
            else MessageBox.Show("Cập nhật dữ liệu không thành công. Vui lòng kiểm tra lại dữ liệu nhập");
        }
    }
}
